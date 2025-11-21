using Application.DTOs;
using Application.Features.ProjectVolunteers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectVolunteerReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectVolunteerReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("volunteer-count")]
        public async Task<ActionResult<List<ProjectVolunteerCountReportDto>>> GetVolunteerCountPerProject()
        {
            return await _mediator.Send(new GetVolunteerCountPerProjectQuery());
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDistributionReportDto>>> GetRoleDistribution()
        {
            return await _mediator.Send(new GetRoleDistributionReportQuery());
        }
    }
}