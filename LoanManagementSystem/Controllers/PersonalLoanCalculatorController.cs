using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Controllers
{
    public class PersonalLoanCalculatorController : Controller
    {
        public IActionResult LoanCalculator()
        {
            return View(new PersonalLoanCalculator());
        }
        [HttpPost]
        public IActionResult LoanCalculator(PersonalLoanCalculator model)
        {
            if (ModelState.IsValid)
            {
                int principal = model.PrincipalAmount.HasValue ? model.PrincipalAmount.Value : 0;
                int numberofterms = model.NumberOfTerms.HasValue ? model.NumberOfTerms.Value : 0;
                double anualrate = 12.00;
                double rate = anualrate / 1200;
                if (numberofterms > 0 && principal > 0 && anualrate > 0)
                {
                    double numerator = principal * rate * Math.Pow(1 + rate, numberofterms);
                    double denominator = Math.Pow(1 + rate, numberofterms) - 1;
                    double payment = numerator / denominator;
                    model.Payment = payment;
                }
                else
                {
                    ModelState.AddModelError("", "Invalid input. Please make sure all fields are filled out with positive numbers (Refer to the Table Below).");
                }
            }
            return View(model);
        }
    }
}
