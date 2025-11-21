using Application.DTOs.ReportDTOs;
using Application.Features.Reports.Donors.Queries;
using Application.Interfaces;
using Application.Interfaces.ReportInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Donors.Handlers
{
    public class GetDonorsByCountryHandler : IRequestHandler<GetDonorsByCountryQuery, List<DonorReportDto>>
    {
        private readonly IDonorReportRepository _donationRepo;

        public GetDonorsByCountryHandler(IDonorReportRepository donationRepo)
        {
            _donationRepo = donationRepo;
        }

        public async Task<List<DonorReportDto>> Handle(GetDonorsByCountryQuery request, CancellationToken cancellationToken)
        {
            var donors = await _donationRepo.GetDonorsByCountryAsync(request.Country);

            return donors.Select(d => new DonorReportDto
            {
                
                    DonorId = d.DonorId,
                    DonorName = d.DonorName,
                    Country = d.Country,
                    TotalAmount = d.TotalAmount,
                    DonationsCount = d.DonationsCount
                }).ToList();
        }
    }
}
