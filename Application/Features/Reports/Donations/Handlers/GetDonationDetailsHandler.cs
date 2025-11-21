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
    public class GetDonationDetailsHandler : IRequestHandler<GetDonationDetailsQuery, DonationReportModuleDto>

    {

        private readonly IDonationReportRepository _donationReportRepo;

        private readonly IMapper _mapper;



        public GetDonationDetailsHandler(IDonationReportRepository donationReportRepo, IMapper mapper)

    {

        _donationReportRepo = donationReportRepo;

        _mapper = mapper;

    }

    public async Task<DonationReportModuleDto> Handle(GetDonationDetailsQuery request, CancellationToken cancellationToken)

    {

        var donation = await _donationReportRepo.GetDonationDetailsAsync(request.DonationId);

        return _mapper.Map<DonationReportModuleDto>(donation);

    }

}

}