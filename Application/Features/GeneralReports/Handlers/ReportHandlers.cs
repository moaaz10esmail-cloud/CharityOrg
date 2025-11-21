using Application.DTOs.ReportDTOs;
using Application.Features.GeneralReports.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GeneralReports.Handlers
{
    public class ReportHandlers : IRequestHandler<GetAllReportsSummaryQuery, List<ReportSummaryDto>>
    {
        public Task<List<ReportSummaryDto>> Handle(GetAllReportsSummaryQuery request, CancellationToken cancellationToken)
        {
            var reports = new List<ReportSummaryDto>
            {
                new ReportSummaryDto { ReportName = "Donor Report" },
                new ReportSummaryDto { ReportName = "Beneficiary Report" },
                new ReportSummaryDto { ReportName = "Donation Report" },
                new ReportSummaryDto { ReportName = "Finance Report" },
                new ReportSummaryDto { ReportName = "Volunteer Report" },
                new ReportSummaryDto { ReportName = "Project Report" },
                new ReportSummaryDto { ReportName = "Staff Report" },
                new ReportSummaryDto { ReportName = "User & Role Report" }
            };

            return Task.FromResult(reports);
        }
    }
}
