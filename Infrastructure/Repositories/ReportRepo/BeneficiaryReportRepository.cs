using Application.DTOs.ReportDTOs;
using Application.Interfaces.ReportInterfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ReportRepo
{
    public class BeneficiaryReportRepository : IBeneficiaryReportRepository
    {
        private readonly CharityDbContext _context;
        private readonly IMapper _mapper;

        public BeneficiaryReportRepository(CharityDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BeneficiaryReportDto>> GetAllBeneficiariesReportAsync()
        {
            var result = await _context.Donations
                .Include(d => d.Beneficiary)
                .GroupBy(d => d.BeneficiaryId)
                .Select(group => new BeneficiaryReportDto
                {
                    BeneficiaryId = group.Key,
                    FullName = group.First().Beneficiary.FullName,
                    DonationsCount = group.Count(),
                    TotalReceived = group.Sum(x => x.Amount)
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<BeneficiaryDonationHistoryDto>> GetDonationHistoryByBeneficiaryAsync(Guid beneficiaryId)
        {
            var donations = await _context.Donations
                .Include(d => d.Donor)
                .Where(d => d.BeneficiaryId == beneficiaryId)
                .OrderByDescending(d => d.DonationDate)
                .ProjectTo<BeneficiaryDonationHistoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return donations;
        }
    }
}