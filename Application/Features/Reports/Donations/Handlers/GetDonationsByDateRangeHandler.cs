using Application.DTOs.ReportDTOs;
using Application.Features.Reports.Donations.Queries;
using Application.Interfaces.ReportInterfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Donations.Handlers
{
    public class GetDonationsByDateRangeHandler : IRequestHandler<GetDonationsByDateRangeQuery, List<DonationReportModuleDto>>

    {

        private readonly IDonationReportRepository _donationReportRepo;

        private readonly IMapper _mapper;

        public GetDonationsByDateRangeHandler(IDonationReportRepository donationReportRepo, IMapper mapper)

        {

            _donationReportRepo = donationReportRepo;

            _mapper = mapper;

        }

        public async Task<List<DonationReportModuleDto>> Handle(GetDonationsByDateRangeQuery request, CancellationToken cancellationToken)

        {

            var donations = await _donationReportRepo.GetDonationsByDateRangeAsync(request.StartDate, request.EndDate);

            return _mapper.Map<List<DonationReportModuleDto>>(donations);

        }

    }

}
