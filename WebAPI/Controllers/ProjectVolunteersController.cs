using Application.DTOs;
using Application.Features.ProjectVolunteers.Commands;
using Application.Features.ProjectVolunteers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectVolunteersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectVolunteersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign(AssignVolunteerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Volunteer assigned to project successfully");
        }

        [HttpPost("unassign")]
        public async Task<IActionResult> Unassign(UnassignVolunteerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Volunteer unassigned from project successfully");
        }

        [HttpGet("by-project/{projectId}")]
        public async Task<ActionResult<List<ProjectVolunteerDto>>> GetByProject(int projectId)
        {
            return await _mediator.Send(new GetVolunteersByProjectQuery { ProjectId = projectId });
        }

        [HttpGet("by-volunteer/{volunteerId}")]
        public async Task<ActionResult<List<ProjectVolunteerDto>>> GetByVolunteer(int volunteerId)
        {
            return await _mediator.Send(new GetProjectsByVolunteerQuery { VolunteerId = volunteerId });
        }
    }
}