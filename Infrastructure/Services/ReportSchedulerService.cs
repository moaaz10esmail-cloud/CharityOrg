using Application.Common.Interfaces;
using Application.DTOs.ReportDTOs;
using Application.Features.Beneficiaries.Queries;
using Application.Features.Employees.Queries;
using Application.Features.Projects.Queries;
using Application.Features.ProjectVolunteers.Queries;
using Application.Features.Reports.Donations.Queries;
using Application.Features.Reports.Donors.Queries;
using Application.Features.Reports.Financial.Queries;
using Hangfire;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Services
{
    public class ReportSchedulerService : IReportSchedulerService
    {
        private readonly IMediator _mediator;
        private readonly IReportExportService _exportService;
        private readonly IEmailService _emailService;

        public ReportSchedulerService(IMediator mediator, IReportExportService exportService, IEmailService emailService)
        {
            _mediator = mediator;
            _exportService = exportService;
            _emailService = emailService;
        }

        public void ScheduleReport(ReportScheduleDto schedule)
        {
            RecurringJob.AddOrUpdate(
                schedule.ReportType + "_Job",
                () => ExecuteScheduledReport(schedule),
                schedule.CronExpression
            );
        }

        public async Task ExecuteScheduledReport(ReportScheduleDto schedule)
        {
            var reportBytes = await GenerateReport(schedule.ReportType, schedule.Format);
            string fileName = $"{schedule.ReportType}_Report.{(schedule.Format.ToLower() == "pdf" ? "pdf" : "xlsx")}";

            if (!string.IsNullOrEmpty(schedule.EmailTo))
            {
                await _emailService.SendEmailAsync(schedule.EmailTo, $"{schedule.ReportType} Report",
                    "Please find attached the scheduled report.", reportBytes, fileName);
            }
            else
            {
                string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string filePath = Path.Combine(folder, fileName);
                await File.WriteAllBytesAsync(filePath, reportBytes);
            }
        }

        public async Task<byte[]> GenerateReport(string reportType, string format)
        {
            string title = $"{reportType} Report";

            switch (reportType.ToLower())
            {

                case "beneficiary":
                    {
                        var data = await _mediator.Send(new GetBeneficiariesListQuery());
                        return format.ToLower() == "pdf"
                            ? _exportService.ExportToPdf(data, title)
                            : _exportService.ExportToExcel(data, title);
                    }


                case "finance":
                    {
                        var summary = await _mediator.Send(new GetFinancialSummaryQuery());
                        var data = new[] { summary };
                        return format.ToLower() == "pdf"
                            ? _exportService.ExportToPdf(data, title)
                            : _exportService.ExportToExcel(data, title);
                    }

                case "volunteer":
                    {
                        var data = await _mediator.Send(new GetVolunteersByProjectQuery());
                        return format.ToLower() == "pdf"
                            ? _exportService.ExportToPdf(data, title)
                            : _exportService.ExportToExcel(data, title);
                    }

                case "project":
                    {
                        var data = await _mediator.Send(new GetProjectDurationsQuery());
                        return format.ToLower() == "pdf"
                            ? _exportService.ExportToPdf(data, title)
                            : _exportService.ExportToExcel(data, title);
                    }


                default:
                    throw new Exception("Unsupported report type");
            }
        }

    }
}
