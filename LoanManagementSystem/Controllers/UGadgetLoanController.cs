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
                AvailablePaymentTerms = paymentTerms,
                GadgetImageURL = gadgetLoan.GadgetImageURL
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

            double interest = (double)(paymentTermEntity.Interest/100);
            decimal payment = (decimal)((gadgetLoan.Price + (gadgetLoan.Price * interest * paymentTermEntity.PaymentTerm)) / (paymentTermEntity.PaymentTerm));

            var model = new PurchaseViewModel
            {
                GadgetLoanId = gadgetId,
                GadgetName = gadgetLoan.GadgetName,
                Description = gadgetLoan.Description,
                Price = gadgetLoan.Price,
                Interest = paymentTermEntity.Interest,
                PaymentTerm = paymentTermEntity.PaymentTerm,
                GadgetImageURL = gadgetLoan.GadgetImageURL,
                Payment = Math.Round(payment, 2)
            };

            TempData["gadgetId"] = gadgetId;
            TempData["paymentTermId"] = paymentTerm;

            return View("ConfirmPurchase", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletePurchase()
        { 
           
            int gadgetId = Convert.ToInt32(TempData["gadgetId"]);
            int paymentTermId = Convert.ToInt32(TempData["paymentTermId"]);

            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            var paymentTermEntity = _dbContext.imps.FirstOrDefault(imp => imp.Id == paymentTermId);

            if (gadgetLoan == null || paymentTermEntity == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            decimal interest = (decimal)paymentTermEntity.Interest;
=======
            //SAME LANG TO NUNG SA CONFIRM PARA LANG DIN MAKUHA YUNG DATA FROM IT
            double interest = (double)(paymentTermEntity.Interest/100);
>>>>>>> 06174aa00f5780a070ca5423f11aaa2fff17984c
            decimal payment = (decimal)((gadgetLoan.Price + (gadgetLoan.Price * interest * paymentTermEntity.PaymentTerm)) / (paymentTermEntity.PaymentTerm));

            var model = new PurchaseViewModel
            {
                GadgetLoanId = gadgetId,
                GadgetName = gadgetLoan.GadgetName,
                Description = gadgetLoan.Description,
                Price = gadgetLoan.Price,
                Interest = paymentTermEntity.Interest,
                PaymentTerm = paymentTermEntity.PaymentTerm,
                Payment = Math.Round(payment, 2),
                GadgetImageURL = gadgetLoan.GadgetImageURL
            };
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var existingPurchase = _dbContext.purchases.FirstOrDefault(p => p.ApplicationUserId == userId && (p.IsArchived == false)); //one purchase only per user if a user has existing purchase and want to have another purchase the user must withdraw their purcahse first
            if (existingPurchase != null)
            {
                ModelState.AddModelError(string.Empty, "You already have an existing gadget loan.");
                return View("PurchaseError");
            }
            var purchase = new Purchase 
            {
                ApplicationUserId = userId,
                GadgetLoanId = model.GadgetLoanId,
                GadgetName = model.GadgetName,
                Description = model.Description,
                Price = (int)model.Price,
                Interest = model.Interest,
                DatePurchased = DateTime.Now,
                GadgetImageURL = model.GadgetImageURL,
                PaymentTerm = model.PaymentTerm,
                Payment = model.Payment,
                Status = "Pending"
        };

            _dbContext.purchases.Add(purchase);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("MyPurchases");
        }

        [HttpGet]
        [Authorize(Roles = "Registered")]
        public async Task<IActionResult> MyPurchases()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var purchases = await _dbContext.purchases
                .Where(p => p.ApplicationUserId == userId)
                .Where(p => !p.IsArchived)
                .ToListAsync();

            return View(purchases);
        }

        [HttpPost]
        [Authorize(Roles = "Registered")]
        public async Task<IActionResult> WithdrawPurchase(int purchaseId)
        {
            var purchase = await _dbContext.purchases.FindAsync(purchaseId);//get purchaseid from db 

            if (purchase == null)
            {
                return NotFound();
            }
            
            // remove the purchase made by the user in the purchase view and put it in the archived
            purchase.IsArchived = true;
            _dbContext.purchases.Update(purchase);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("MyPurchases");
        }

        [Authorize(Roles = "Administrator, Registered")]
        public IActionResult ArchivedPurchases() //kaya di ako naka async para matrigger lang sya once gagamitin na pineprevent kodin na di maload ng db ng purchase ito kasabay ng ibang task
        {
            var deactivePurchases = _dbContext.purchases.Where(p => p.IsArchived).ToList();
            return View(deactivePurchases);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeletePurchase(int purchaseId)
        {
            var purchase = await _dbContext.purchases.FindAsync(purchaseId);//get purchaseid from db 

            if (purchase == null)
            {
                return NotFound();
            }

            _dbContext.purchases.Remove(purchase);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Purchases");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ApprovePurchase(int purchaseId)
        {
            var purchase = await _dbContext.purchases.FindAsync(purchaseId);

            if (purchase == null)
            {
                return NotFound();
            }

            purchase.Status = "Approved";
            purchase.IsArchived = false;
            _dbContext.Update(purchase);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Purchases", "UGadgetLoan");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeclinePurchase(int purchaseId)
        {
            var purchase = await _dbContext.purchases.FindAsync(purchaseId);

            if (purchase == null)
            {
                return NotFound();
            }

            purchase.Status = "Declined";
            purchase.IsArchived = true;
            _dbContext.Update(purchase);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Purchases", "UGadgetLoan");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Purchases()
        {
            var purchases = await _dbContext.purchases
                .Include(p => p.ApplicationUser)
                .Where(p => !p.IsArchived)
                .ToListAsync();

            return View(purchases);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Registered")]
        public async Task<IActionResult> PurchaseDetails(int id)
        {
            // Find the purchase by ID in the database
            var purchase = await _dbContext.purchases
                .Include(p => p.ApplicationUser)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (purchase == null)
            {
                // Return a not found response if the purchase is not found
                return NotFound();
            }

            // Pass the purchase object to the view for displaying the details
            return View(purchase);
        }
    }
}
