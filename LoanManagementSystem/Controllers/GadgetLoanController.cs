using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanManagementSystem.Controllers
{
    public class GadgetLoanController : Controller
    {
        private readonly IGadgetLoanRepository _gadgetLoanRepository;

        public GadgetLoanController(IGadgetLoanRepository gadgetLoanRepository)
        {
            _gadgetLoanRepository = gadgetLoanRepository;
        }

        public async Task<IActionResult> GetAllGadgets()
        {
            var gadgets = await _gadgetLoanRepository.GetAllGadgets();
            return View(gadgets);
        }

        public async Task<IActionResult> Details(int gadgetId)
        {
            
            var gadget = await _gadgetLoanRepository.GetGadgetById(gadgetId);
            if (gadget == null)
            {
                return NotFound();
            }

            return View(gadget);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GadgetLoan newGadget)
        {
            
            if (ModelState.IsValid)
            {
                await _gadgetLoanRepository.AddGadget(newGadget);
                return RedirectToAction(nameof(Index));
            }

            return View(newGadget);
        }

        public async Task<IActionResult> Update(int gadgetId)
        {
            var gadget = await _gadgetLoanRepository.GetGadgetById(gadgetId);
            if (gadget == null)
            {
                return NotFound();
            }

            return View(gadget);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int gadgetId, GadgetLoan updatedGadget)
        {
            
            if (gadgetId != updatedGadget.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _gadgetLoanRepository.UpdateGadget(gadgetId, updatedGadget);
                return RedirectToAction(nameof(Index));
            }

            return View(updatedGadget);
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int gadgetId)
        {
            var token = HttpContext.Session.GetString("JWToken");
            await _gadgetLoanRepository.DeleteGadget(gadgetId);
            return RedirectToAction(nameof(Index));
        }*/
    }
}
