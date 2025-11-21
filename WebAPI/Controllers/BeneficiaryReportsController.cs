using Application.Features.Reports.Beneficiaries.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Manager,SuperAdmin")]
    public class BeneficiaryReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeneficiaryReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all beneficiaries with donation statistics.
        /// </summary>
        [HttpGet("with-stats")]
        public async Task<IActionResult> GetWithStats()
        {
            var result = await _mediator.Send(new GetBeneficiariesWithStatsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Get donation history for a specific beneficiary.
        /// </summary>
        [HttpGet("{beneficiaryId}/history")]
        public async Task<IActionResult> GetHistory(Guid beneficiaryId)
        {
            var result = await _mediator.Send(new GetBeneficiaryHistoryQuery { BeneficiaryId = beneficiaryId });
            return Ok(result);
        }
    }
}