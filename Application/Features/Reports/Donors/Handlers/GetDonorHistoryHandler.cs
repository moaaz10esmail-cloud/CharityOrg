using Application.DTOs.ReportDTOs;
using Application.Features.Reports.Donors.Queries;
using Application.Interfaces;
using Application.Interfaces.ReportInterfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Donors.Handlers
{
    public class GetDonorHistoryHandler : IRequestHandler<GetDonorHistoryQuery, List<DonorDonationHistoryDto>>
    {
        private readonly IDonorReportRepository _donationRepo;
        private readonly IMapper _mapper;

        public GetDonorHistoryHandler(IDonorReportRepository donationRepo, IMapper mapper)
        {
            _donationRepo = donationRepo;
            _mapper = mapper;
        }

        public async Task<List<DonorDonationHistoryDto>> Handle(GetDonorHistoryQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepo.GetDonationsByDonorAsync(request.DonorId);
            return _mapper.Map<List<DonorDonationHistoryDto>>(donations);
        }
    }
}
