using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.Models;
using LoanManagementSystem.ViewModel;
using LoanManagementSystem.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Purchase()
        {
            return View();
        }


        [Route("UGadgetLoan/ConfirmPurchase")]
        public ActionResult ConfirmPurchase([FromQuery] int gadgetId, int? impId)
        {
            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            IMP? paymentTerm = null;
            if (impId != null)
            {
                paymentTerm = _dbContext.imps.FirstOrDefault(imp => imp.Id == impId);
            }
            else
            {
                paymentTerm = _dbContext.imps.FirstOrDefault(imp => imp.Id == gadgetId);
            }

            var paymentTerms = _dbContext.imps.Select(imp => imp.PaymentTerm).Distinct().ToList();

            if (gadgetLoan == null)
            {
                return NotFound();
            }
            var model = new PurchaseViewModel
            {
                GadgetLoanId = gadgetId,
                GadgetName = gadgetLoan.GadgetName,
                Description = gadgetLoan.Description,
                Price = gadgetLoan.Price,
                Interest = paymentTerm.Interest,
                PaymentTerm = paymentTerm.PaymentTerm,
                Payment = CalculatePayment(gadgetLoan.Price, (decimal)paymentTerm.Interest, paymentTerm.PaymentTerm),
                AvailablePaymentTerms = paymentTerms
            };

            return View(model);
        }

        public ActionResult Recalculate(int gadgetId, int impId)
        {
            return RedirectToAction(controllerName: "UGadgetLoan", actionName: "ConfirmPurchange", routeValues: new { gadgetId = gadgetId, impId = impId });
        }

        private decimal CalculatePayment(decimal price, decimal interest, int paymentTerm)
        {
            decimal monthlyInterest = interest / 100 / paymentTerm;
            decimal payment = (price * monthlyInterest) / (1 - (decimal)Math.Pow(1 + (double)monthlyInterest, -paymentTerm));

            return Math.Round(payment, 2);
        }


    }
}
