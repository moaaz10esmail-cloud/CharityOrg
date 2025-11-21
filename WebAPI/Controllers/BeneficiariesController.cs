using Application.Features.Beneficiaries.Commands;
using Application.Features.Beneficiaries.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,SuperAdmin,ProjectManager")]
    public class BeneficiariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeneficiariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBeneficiaryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetBeneficiariesListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetBeneficiaryByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBeneficiaryCommand command)
        {
            if (id != command.Id) return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);
            if (!result) return NotFound();

            return Ok("Beneficiary updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteBeneficiaryCommand { Id = id });
            if (!result) return NotFound();

            return Ok("Beneficiary deleted successfully");
        }
    }
}

