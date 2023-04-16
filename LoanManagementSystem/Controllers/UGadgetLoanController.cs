using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.Models;
using LoanManagementSystem.ViewModel;
using LoanManagementSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.VisualBasic;
using System.Security.Claims;


namespace LoanManagementSystem.Controllers
{
    [Authorize]
    public class UGadgetLoanController : Controller
    {
        private readonly ILogger<UGadgetLoanController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UGadgetLoanController(ApplicationDbContext dbContext, ILogger<UGadgetLoanController> logger, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Purchase(int gadgetId)
        {
            var gadgetLoan =  await _dbContext.gadgetloans.FirstOrDefaultAsync(gl => gl.Id == gadgetId);

            if (gadgetLoan == null)
            {
                return NotFound();
            }

            var paymentTerms =  await _dbContext.imps.ToListAsync();

            if (paymentTerms == null)
            {
                paymentTerms = new List<IMP>();
            }

            var model = new PurchaseViewModel
            {
                GadgetLoanId = gadgetId,
                GadgetName = gadgetLoan.GadgetName,
                Description = gadgetLoan.Description,
                Price = gadgetLoan.Price,
                AvailablePaymentTerms = paymentTerms
            };

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmPurchase(int gadgetId, int paymentTerm)
        {

            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            var paymentTermEntity = _dbContext.imps.FirstOrDefault(imp => imp.Id == paymentTerm);

            if (gadgetLoan == null || paymentTermEntity == null)
            {
                return NotFound();
            }

            decimal interest = (decimal)paymentTermEntity.Interest;
            decimal payment = (decimal)((gadgetLoan.Price + (gadgetLoan.Price * interest * paymentTermEntity.PaymentTerm)) / (paymentTermEntity.PaymentTerm));

            var model = new PurchaseViewModel
            {
                GadgetLoanId = gadgetId,
                GadgetName = gadgetLoan.GadgetName,
                Description = gadgetLoan.Description,
                Price = gadgetLoan.Price,
                Interest = paymentTermEntity.Interest,
                PaymentTerm = paymentTermEntity.PaymentTerm,
                Payment = Math.Round(payment, 2)
            };

            //GINAMIT KOTO PARA MAKUHA KO YUNG PIPILIIN NI USER NA GADGET AT PAYMENT TERM AT MA MAP SA COMPLETEPURCHASE AT YUN NAMAN YUNG GAGAMITIN PARA MAG SAVE NG DATA SA PURCHASE TABLE
            TempData["gadgetId"] = gadgetId;
            TempData["paymentTermId"] = paymentTerm;

            return View("ConfirmPurchase", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletePurchase()//KAYA NAG ADD ULIT AKO NG ACTION KASI PAG NASA CONFIRM YUNG PAG SASAVE NG PURCHASE MAG KAKABUG KASI KAHIT HINDI MAG CONFIRM YUNG USER MAG KAKAROON NG TOKEN ID YUNG PURCHASE SO KAYA NISEPARATE KO
        {
            //COCONVERT KO ULIT YUNG NAKUHANG DATA SA TEMP TO INT32 NA MAGAGAMIT NAMAN SA SUCCEEDING OPERATION AT YAN NADIN YUNG MAGSISILBING HOLDER NUNG DATA
            int gadgetId = Convert.ToInt32(TempData["gadgetId"]);
            int paymentTermId = Convert.ToInt32(TempData["paymentTermId"]);

            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            var paymentTermEntity = _dbContext.imps.FirstOrDefault(imp => imp.Id == paymentTermId);

            if (gadgetLoan == null || paymentTermEntity == null)
            {
                return NotFound();
            }

            //SAME LANG TO NUNG SA CONFIRM PARA LANG DIN MAKUHA YUNG DATA FROM IT
            decimal interest = (decimal)paymentTermEntity.Interest;
            decimal payment = (decimal)((gadgetLoan.Price + (gadgetLoan.Price * interest * paymentTermEntity.PaymentTerm)) / (paymentTermEntity.PaymentTerm));

            var model = new PurchaseViewModel
            {
                GadgetLoanId = gadgetId,
                GadgetName = gadgetLoan.GadgetName,
                Description = gadgetLoan.Description,
                Price = gadgetLoan.Price,
                Interest = paymentTermEntity.Interest,
                PaymentTerm = paymentTermEntity.PaymentTerm,
                Payment = Math.Round(payment, 2)
            };

            // CODE PARA MAKUHA YUNG CURRENT USER ISYSYNC NYA TO SA TOKEN NA NAKUKUHA SA LOGIN USING USER MANAGER
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // KUHAIN NYA YUNG ID NG USER SYA DATABASE ITO YUNG CURRENT
            var user = await _userManager.FindByIdAsync(userId);//OPTIONAL LANG TO PERO NILAGAY KONA DIN BAKA KASI MAG KA BUG PAG HAHANAP
            var purchase = new Purchase //NAG GAWA LANG AKO NG PANIBAGONG MODEL PARA MAHOLD YUNG VALUE NA MAKUKUHA SA CONFIRM PURCHASE USING TEMPDATA
            {
                ApplicationUserId = userId,
                GadgetLoanId = model.GadgetLoanId,
                GadgetName = model.GadgetName,
                Description = model.Description,
                Price = (int)model.Price,
                Interest = model.Interest,
                DatePurchased = DateTime.Now,
                PaymentTerm = model.PaymentTerm,
                Payment = model.Payment
            };

            //TAPOS SASAVE KO SA DB NG PURCHASE KADA MAY COCOMPLETE PURCHASE YUNG USER
            _dbContext.purchases.Add(purchase);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("MyPurchases");//MAY PROBLEMA PA DITO PERO PUSH KONA SA GIT PARA MAKITA MO CHANGES KO
        }

        [HttpGet]
        public async Task<IActionResult> MyPurchases()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var purchases = await _dbContext.purchases
                .Where(p => p.ApplicationUserId == userId)
                .ToListAsync();

            return View(purchases);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Purchases()
        {
            var purchases = await _dbContext.purchases
                .Include(p => p.ApplicationUser)
                .ToListAsync();

            return View(purchases);
        }

       
    }
}
