using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.Models;
using LoanManagementSystem.ViewModel;
using LoanManagementSystem.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.VisualBasic;

namespace LoanManagementSystem.Controllers
{
    [Authorize]
    public class UGadgetLoanController : Controller
    {
        private readonly ILogger<UGadgetLoanController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public UGadgetLoanController(ApplicationDbContext dbContext, ILogger<UGadgetLoanController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Purchase(int gadgetId)
        {
            var gadgetLoan =  _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);

            if (gadgetLoan == null)
            {
                return NotFound();
            }

            var paymentTerms =  _dbContext.imps.ToList();

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
        private Purchase CreatePurchase(int gadgetId, int paymentTermId, decimal payment, decimal interestAmount)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == User.Identity.Name);
            if (user == null)
            {
                return null;
            }

            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            if (gadgetLoan == null)
            {
                return null;
            }

            var paymentTermEntity = _dbContext.imps.FirstOrDefault(imp => imp.Id == paymentTermId);
            if (paymentTermEntity == null)
            {
                return null;
            }

            var purchase = new Purchase
            {
                ApplicationUserId = User.Identity.Name,
                GadgetLoan = gadgetLoan,
                PaymentTerm = paymentTermEntity,
                Payment = payment,
                Interest = interestAmount,
                DatePurchased = DateTime.Now
            };
            _dbContext.purchases.Add(purchase);
            _dbContext.SaveChanges();
            return purchase;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmPurchase(int gadgetId, int paymentTerm)
        {
            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            var paymentTermEntity = _dbContext.imps.FirstOrDefault(imp => imp.Id == paymentTerm);

            if (gadgetLoan == null || paymentTermEntity == null)
            {
                return NotFound();
            }

            decimal payment = (decimal)((gadgetLoan.Price +(gadgetLoan.Price * paymentTermEntity.Interest * paymentTermEntity.PaymentTerm)) /(paymentTermEntity.PaymentTerm));
            var model = new PurchaseViewModel
            {
                GadgetLoanId = gadgetId,
                GadgetName = gadgetLoan.GadgetName,
                Description = gadgetLoan.Description,
                Price = gadgetLoan.Price,
                Interest = (decimal)paymentTermEntity.Interest,
                PaymentTerm = paymentTermEntity.PaymentTerm,
                Payment = Math.Round(payment, 2)
            };
           return View("ConfirmPurchase", model);
        }

        [HttpGet]
        [Authorize(Roles = "Registered")]
        public async Task<IActionResult> MyPurchases()
        {
            var purchases = await _dbContext.purchases.
                Where(p => p.ApplicationUserId == User.Identity.Name)
                   .Include(p => p.GadgetLoan)
                   .Include(p => p.PaymentTerm)
                   .ToListAsync();
            return View(purchases);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Purchases()
        {
            var purchases = await _dbContext.purchases
                .Include(p => p.ApplicationUser)
                .Include(p => p.GadgetLoan)
                .Include(p => p.PaymentTerm)
                .ToListAsync();

            var model = new AdminPurchasesViewModel
            {
                Purchases = purchases.Select(p => new PurchaseViewModel
                {
                    Id = p.Id,
                    GadgetLoanId = p.GadgetLoanId,
                    GadgetName = p.GadgetLoan.GadgetName,
                    Description = p.GadgetLoan.Description,
                    Price = p.GadgetLoan.Price,
                    PaymentTerm = p.PaymentTerm.Id,
                    Interest = p.Interest,
                    Payment = p.Payment,
                    UserId = p.ApplicationUserId,
                    UserName = p.ApplicationUser.UserName
                }).ToList()
            };
            return View(model);
        }

    }
}
