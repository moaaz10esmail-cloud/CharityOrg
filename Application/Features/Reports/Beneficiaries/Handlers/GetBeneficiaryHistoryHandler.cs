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
    public class GetBeneficiaryHistoryHandler : IRequestHandler<GetBeneficiaryHistoryQuery, List<BeneficiaryDonationHistoryDto>>
    {
        private readonly IBeneficiaryReportRepository _repository;

        public GetBeneficiaryHistoryHandler(IBeneficiaryReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BeneficiaryDonationHistoryDto>> Handle(GetBeneficiaryHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDonationHistoryByBeneficiaryAsync(request.BeneficiaryId);
        }
    }
}