using Application.DTOs;
using Application.Features.Volunteers.Commands;
using Application.Features.Volunteers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VolunteersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<VolunteerDto>>> GetAll()
        {
            return await _mediator.Send(new GetAllVolunteersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VolunteerDto>> GetById(int id)
        {
            return await _mediator.Send(new GetVolunteerByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVolunteerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateVolunteerCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteVolunteerCommand { Id = id });
            return NoContent();
        }
    }
}