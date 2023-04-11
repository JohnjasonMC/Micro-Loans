using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LoanManagementSystem.Controllers
{
    [Authorize]
    public class GadgetLoanController : Controller
    {
        IGadgetLoanRepository _repo;

        public GadgetLoanController(IGadgetLoanRepository repo)
        {
            this._repo = repo;
        }

        [AllowAnonymous]
        public IActionResult GetAllGadgets()
        {
            var gadgetlist = _repo.GetAllGadgets();
            return View(gadgetlist);
        }

        [AllowAnonymous]
        public IActionResult Details(int gadgetId)
        {
            var gadget = _repo.GetGadgetById(gadgetId);
            return View(gadget);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int gadgetId)
        {
            var gadgetlist = _repo.DeleteGadget(gadgetId);
            return RedirectToAction(controllerName: "GadgetLoan", actionName: "GetAllGadgets");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create(GadgetLoan newGadget)
        {
            if (ModelState.IsValid)
            {
                var gadget = _repo.AddGadget(newGadget);
                return RedirectToAction("GetAllGadgets");
            }
            ViewData["Message"] = "Data is not valid to create gadget";
            return View(newGadget);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Update(int gadgetId)
        {
            var oldGadget = _repo.GetGadgetById(gadgetId);
            return View(oldGadget);
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Update(GadgetLoan newGadgetLoan)
        {
            if (ModelState.IsValid)
            {
                var gadget = _repo.UpdateGadget(newGadgetLoan.Id, newGadgetLoan);
                return RedirectToAction("GetAllGadgets");
            }
            ViewData["Message"] = "Data is not valid to create gadget";
            return View(newGadgetLoan);
        }


    }
}
