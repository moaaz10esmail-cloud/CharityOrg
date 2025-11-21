using Application.Features.Reports.Donors.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Manager,SuperAdmin")]
    public class DonorReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonorReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopDonors([FromQuery] int count = 10)
        {
            var result = await _mediator.Send(new GetTopDonorsQuery { Count = count });
            return Ok(result);
        }

        [HttpGet("by-country/{country}")]
        public async Task<IActionResult> GetDonorsByCountry(string country)
        {
            var result = await _mediator.Send(new GetDonorsByCountryQuery { Country = country });
            return Ok(result);
        }

        [HttpGet("{donorId}/history")]
        public async Task<IActionResult> GetDonorHistory(Guid donorId)
        {
            var result = await _mediator.Send(new GetDonorHistoryQuery { DonorId = donorId });
            return Ok(result);
        }
    }
}
