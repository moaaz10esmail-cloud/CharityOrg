using Application.DTOs.ReportDTOs;
using Application.Features.Projects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("statuses")]
        public async Task<ActionResult<List<ProjectStatusReportDto>>> GetProjectStatuses()
        {
            return await _mediator.Send(new GetProjectStatusesQuery());
        }

        [HttpGet("durations")]
        public async Task<ActionResult<List<ProjectDurationReportDto>>> GetProjectDurations()
        {
            return await _mediator.Send(new GetProjectDurationsQuery());
        }

        [HttpGet("summary")]
        public async Task<ActionResult<ProjectSummaryReportDto>> GetProjectSummary()
        {
            return await _mediator.Send(new GetProjectSummaryQuery());
        }
    }
}