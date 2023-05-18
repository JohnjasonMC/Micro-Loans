using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanManagementSystem.Controllers
{
    [Authorize]
    public class GadgetLoanController : Controller
    {
        private readonly IGadgetLoanRepository _gadgetLoanRepository;

        public GadgetLoanController(IGadgetLoanRepository gadgetLoanRepository)
        {
            _gadgetLoanRepository = gadgetLoanRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetAllGadgets()
        {
            var gadgets = await _gadgetLoanRepository.GetAllGadgets();
            return View(gadgets);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var gadget = await _gadgetLoanRepository.GetGadgetById(id);
            if (gadget == null)
            {
                return NotFound();
            }
            return View(gadget);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GadgetLoan gadget)
        {
            if (ModelState.IsValid)
            {
                await _gadgetLoanRepository.AddGadget(gadget);
                return RedirectToAction(nameof(Index));
            }
            return View(gadget);
        }

        public async Task<IActionResult> Update(int id)
        {
            var gadget = await _gadgetLoanRepository.GetGadgetById(id);
            if (gadget == null)
            {
                return NotFound();
            }
            return View(gadget);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, GadgetLoan gadget)
        {
            if (id != gadget.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _gadgetLoanRepository.UpdateGadget(id, gadget);
                return RedirectToAction(nameof(Index));
            }
            return View(gadget);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var gadget = await _gadgetLoanRepository.GetGadgetById(id);
            if (gadget == null)
            {
                return NotFound();
            }
            await _gadgetLoanRepository.DeleteGadget(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
