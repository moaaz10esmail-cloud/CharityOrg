using Application.Common.Interfaces;
using Application.Features.Reports.Donors.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Manager")]
    public class ReportExportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IReportExportService _exportService;

        public ReportExportController(IMediator mediator, IReportExportService exportService)
        {
            _mediator = mediator;
            _exportService = exportService;
        }

        [HttpGet("donors/pdf")]
        public async Task<IActionResult> ExportDonorsPdf()
        {
            var data = await _mediator.Send(new GetDonorHistoryQuery());
            var file = _exportService.ExportToPdf(data, "Donor Report");
            return File(file, "application/pdf", "DonorReport.pdf");
        }

    }
}