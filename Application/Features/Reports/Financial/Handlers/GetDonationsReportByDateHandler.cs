using Application.DTOs.ReportDTOs;
using Application.Features.Reports.Financial.Queries;
using Application.Interfaces.ReportInterfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Financial.Handlers
{
    public class GetDonationsReportByDateHandler : IRequestHandler<GetDonationsReportByDateQuery, List<DonationReportModuleDto>>
    {

        private readonly IDonationFinanceReportRepository _donationRepo;
        private readonly IMapper _mapper;

        public GetDonationsReportByDateHandler(IDonationFinanceReportRepository donationRepo, IMapper mapper)
        {
            _donationRepo = donationRepo;
            _mapper = mapper;
        }

        public async Task<List<DonationReportModuleDto>> Handle(GetDonationsReportByDateQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepo.GetDonationsByDateRangeAsync(request.StartDate, request.EndDate);
            return _mapper.Map<List<DonationReportModuleDto>>(donations);
        }
    }
}
