using Application.Features.Donations.Commands;
using Application.Features.Donations.Handlers;
using Application.Features.Donations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,SuperAdmin,Finance")]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetDonationsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetDonationByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDonationCommand command)
        {
            if (id != command.Id) return BadRequest();

            var result = await _mediator.Send(command);
            if (!result) return NotFound();

            return Ok("Donation updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteDonationCommand { Id = id });
            if (!result) return NotFound();

            return Ok("Donation deleted successfully");
        }

        [HttpGet("donor/{donorId}")]
        public async Task<IActionResult> GetByDonor(Guid donorId)
        {
            var result = await _mediator.Send(new GetDonationsByDonorQuery { DonorId = donorId });
            return Ok(result);
        }

        [HttpGet("beneficiary/{beneficiaryId}")]
        public async Task<IActionResult> GetByBeneficiary(Guid beneficiaryId)
        {
            var result = await _mediator.Send(new GetDonationsByBeneficiaryQuery { BeneficiaryId = beneficiaryId });
            return Ok(result);
        }
    }
}