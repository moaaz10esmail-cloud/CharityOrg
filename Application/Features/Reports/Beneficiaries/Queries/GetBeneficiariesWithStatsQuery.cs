using Application.DTOs.ReportDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Beneficiaries.Queries
{
    public class GetBeneficiariesWithStatsQuery : IRequest<List<BeneficiaryReportDto>>
    {
    }
}
