using Application.Features.Reports.Financial.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,SuperAdmin,Finance,Manager")]
    public class FinanceReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinanceReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  1. ملخص مالي (تبرعات + مصروفات + رصيد)
        [HttpGet("summary")]
        public async Task<IActionResult> GetFinancialSummary([FromQuery] string currency = "USD")
        {
            var result = await _mediator.Send(new GetFinancialSummaryQuery { Currency = currency });
            return Ok(result);
        }

        //  2. تقرير التبرعات حسب الفترة
        [HttpGet("donations-by-date")]
        public async Task<IActionResult> GetDonationsByDate([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var result = await _mediator.Send(new GetDonationsReportByDateQuery
            {
                StartDate = start,
                EndDate = end
            });
            return Ok(result);
        }

    }
}

