using Application.Features.Donors.Commands;
using Application.Features.Donors.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,SuperAdmin,FinanceManager")]
    public class DonorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDonor([FromBody] CreateDonorCommand command)
        {
            var donor = await _mediator.Send(command);
            return Ok(donor);
        }

        [HttpGet]
        public async Task<IActionResult> GetDonors()
        {
            var donors = await _mediator.Send(new GetDonorsListQuery());
            return Ok(donors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(Guid id)
        {
            var donor = await _mediator.Send(new GetDonorByIdQuery { Id = id });
            if (donor == null) return NotFound();
            return Ok(donor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor(Guid id, [FromBody] UpdateDonorCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            if (!result) return NotFound();

            return Ok("Donor updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(Guid id)
        {
            var result = await _mediator.Send(new DeleteDonorCommand { Id = id });
            if (!result) return NotFound();

            return Ok("Donor deleted successfully");
        }
    }
}
