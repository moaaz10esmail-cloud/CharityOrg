using Application.DTOs.ReportDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Donors.Queries
{
    public class GetDonorsByCountryQuery : IRequest<List<DonorReportDto>>
    {
        public string Country { get; set; } = string.Empty;
    }
}
