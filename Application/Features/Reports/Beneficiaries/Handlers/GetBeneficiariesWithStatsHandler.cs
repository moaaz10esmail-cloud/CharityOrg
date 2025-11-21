using Application.DTOs.ReportDTOs;
using Application.Features.Reports.Beneficiaries.Queries;
using Application.Interfaces.ReportInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Beneficiaries.Handlers
{
    public class GetBeneficiariesWithStatsHandler : IRequestHandler<GetBeneficiariesWithStatsQuery, List<BeneficiaryReportDto>>
    {
        private readonly IBeneficiaryReportRepository _repository;

        public GetBeneficiariesWithStatsHandler(IBeneficiaryReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BeneficiaryReportDto>> Handle(GetBeneficiariesWithStatsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllBeneficiariesReportAsync();
        }
    }
}