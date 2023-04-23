using AutoMapper;
using LmsAPI.DTO;
using LmsAPI.Models;
using LmsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LmsAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetLoanController : ControllerBase
    {
        IGadgetLoanRepository _repo;
        private readonly IMapper _mapper;

        public GadgetLoanController(IGadgetLoanRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet("Get All Gadgets")]
        public IActionResult GetAllGadgets()
        {
            return Ok(this._repo.GetAllGadgets());
        }


        [HttpGet("Get Gadget")]
        public async Task<IActionResult> GetById([FromRoute] int gadgetId) 
        {
            if (gadgetId == 0)
                return BadRequest();
            try
            {
                var gadgetLoan = await _repo.GetGadgetById(gadgetId);
                if (gadgetLoan == null)
                    return NoContent();
                return Ok(gadgetLoan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromRoute] int gadgetId)
        {
            if (gadgetId == 0)
                return BadRequest();
            var gadgetloan = await _repo.GetGadgetById(gadgetId);
            if (gadgetloan == null)
                return NotFound("No Resource Found");
            await _repo.DeleteGadget(gadgetId);
            return Accepted();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] GadgetLoanDTO gadgetLoanDTO)
        {
            if (gadgetLoanDTO == null)
                return BadRequest("No Data Provided");
            if (ModelState.IsValid)
            {
                var gadgetloan = _mapper.Map<GadgetLoan>(gadgetLoanDTO);
                var newgadgetloan = _repo.AddGadget(gadgetloan);
                return CreatedAtAction("GetById", new { gadgetId = newgadgetloan.Id }, newgadgetloan);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] GadgetLoan newGadgetLoan, [FromRoute] int gadgetId)
        {
            if (newGadgetLoan == null)
                return BadRequest("No Data Provided");
            if (ModelState.IsValid)
            {
                var updateGadgetloan = _repo.UpdateGadget(gadgetId, newGadgetLoan);
                return AcceptedAtAction("GetById", new { gadgetId = updateGadgetloan.Id }, updateGadgetloan);
            }
            return BadRequest(ModelState);
        }
    }
}
