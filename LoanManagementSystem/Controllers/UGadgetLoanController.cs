/*
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

        [HttpGet]
        public IActionResult ConfirmPurchase(int gadgetId)
        {
            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);

            if (gadgetLoan == null)
            {
                return NotFound();
            }

            var paymentTerms = _dbContext.imps.ToList();

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
        public IActionResult ConfirmPurchase(int gadgetId, int paymentTerm)
        {
            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            var paymentTermEntity = _dbContext.imps.FirstOrDefault(imp => imp.Id == paymentTerm);

            if (gadgetLoan == null || paymentTermEntity == null)
            {
                return NotFound();
            }

            decimal monthlyInterest = (decimal)(paymentTermEntity.Interest / 100 / paymentTermEntity.PaymentTerm);
            decimal payment = (gadgetLoan.Price * monthlyInterest) / (1 - (decimal)Math.Pow(1 + (double)monthlyInterest, -paymentTermEntity.PaymentTerm));

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

            return View("ConfirmPurchase", model);
        }

    }
}
*/

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
        public IActionResult Purchase(int gadgetId)
        {
            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);

            if (gadgetLoan == null)
            {
                return NotFound();
            }

            var paymentTerms = _dbContext.imps.ToList();

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
        public IActionResult ConfirmPurchase(int gadgetId, int paymentTerm)
        {
            var gadgetLoan = _dbContext.gadgetloans.FirstOrDefault(gl => gl.Id == gadgetId);
            var paymentTermEntity = _dbContext.imps.FirstOrDefault(imp => imp.Id == paymentTerm);

            if (gadgetLoan == null || paymentTermEntity == null)
            {
                return NotFound();
            }

            decimal monthlyInterest = (decimal)(paymentTermEntity.Interest / 100 / paymentTermEntity.PaymentTerm);
            decimal payment = (gadgetLoan.Price * monthlyInterest) / (1 - (decimal)Math.Pow(1 + (double)monthlyInterest, -paymentTermEntity.PaymentTerm));

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

            return View("ConfirmPurchase", model);
        }
    }
}
