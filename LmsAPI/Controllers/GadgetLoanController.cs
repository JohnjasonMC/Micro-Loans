using AutoMapper;
using LmsAPI.DTO;
using LmsAPI.Models;
using LmsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LmsAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetLoanController : ControllerBase
    {
        private readonly IGadgetLoanRepository _gadgetLoanRepository;

        public GadgetLoanController(IGadgetLoanRepository gadgetLoanRepository)
        {
            _gadgetLoanRepository = gadgetLoanRepository;
        }

        [HttpGet("{gadgetId}")]
        public async Task<ActionResult<GadgetLoan>> GetGadgetById(int gadgetId)
        {
            var gadget = await _gadgetLoanRepository.GetGadgetById(gadgetId);

            if (gadget == null)
            {
                return NotFound();
            }

            return Ok(gadget);
        }

        [HttpGet]
        public async Task<ActionResult<List<GadgetLoan>>> GetAllGadgets()
        {
            var gadgets = await _gadgetLoanRepository.GetAllGadgets();
            return Ok(gadgets);
        }

        [HttpPost]
        public ActionResult<GadgetLoan> AddGadget(GadgetLoan newGadget)
        {
            var addedGadget = _gadgetLoanRepository.AddGadget(newGadget);
            return Ok(addedGadget);
        }

        [HttpPut("{gadgetId}")]
        public IActionResult UpdateGadget(int gadgetId, GadgetLoan updatedGadget)
        {
            _gadgetLoanRepository.UpdateGadget(gadgetId, updatedGadget);
            return NoContent();
        }

        [HttpDelete("{gadgetId}")]
        public IActionResult DeleteGadget(int gadgetId)
        {
            _gadgetLoanRepository.DeleteGadget(gadgetId);
            return NoContent();
        }
    }
}
