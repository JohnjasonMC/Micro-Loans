using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
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

        // GET: GadgetLoan/Details/
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gadgetloan = await _gadgetLoanRepository.GetGadgetById(id);
            return View(gadgetloan);
        }

        // GET: GadgetLoan/Index
        public async Task<IActionResult> GetAllGadgets()
        {
            // Get the token from the HttpContext session
            var token = HttpContext.Session.GetString("JWToken");

            var gadgetloans = await _gadgetLoanRepository.GetAllGadgets(token);
            return View(gadgetloans);
        }

        // GET: GadgetLoan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GadgetLoan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GadgetLoan newGadget)
        {
            // Get the token from the HttpContext session
            var token = HttpContext.Session.GetString("JWToken");

            var createdGadget = await _gadgetLoanRepository.AddGadget(newGadget, token);
            if (createdGadget != null)
            {
                return RedirectToAction(nameof(Details), new { id = createdGadget.Id });
            }
            return View(newGadget);
        }

        // GET: GadgetLoan/Edit/
        public async Task<IActionResult> Update(int id)
        {
            var gadgetloan = await _gadgetLoanRepository.GetGadgetById(id);
            if (gadgetloan != null)
            {
                return View(gadgetloan);
            }
            return NotFound();
        }

        // POST: GadgetLoan/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GadgetLoan updatedGadget)
        {
            var token = HttpContext.Session.GetString("JWToken");
            await _gadgetLoanRepository.UpdateGadget(updatedGadget.Id, updatedGadget, token);
            return RedirectToAction("GetAllGadgets");
        }

        // GET: GadgetLoan/Delete/
        public async Task<IActionResult> Delete(int id)
        {
            // Get the token from the HttpContext session
            var token = HttpContext.Session.GetString("JWToken");

            await _gadgetLoanRepository.DeleteGadget(id, token);
            return RedirectToAction(nameof(Index));
        }
    }
}
