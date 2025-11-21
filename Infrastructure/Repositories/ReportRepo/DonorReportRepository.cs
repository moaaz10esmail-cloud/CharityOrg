using Application.DTOs.ReportDTOs;
using Application.Interfaces.ReportInterfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repositories.ReportRepo
{
    public class DonorReportRepository : IDonorReportRepository
    {
        private readonly CharityDbContext _context;
        private readonly IMapper _mapper;

        public DonorReportRepository(CharityDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DonorReportDto>> GetTopDonorsAsync(int count)
        {
            var result = await _context.Donations
                .Include(d => d.Donor)
                .GroupBy(d => d.DonorId)
                .Select(group => new DonorReportDto
                {
                    DonorId = group.Key,
                    DonorName = group.First().Donor.FullName,
                    Country = group.First().Donor.Country,
                    TotalAmount = group.Sum(x => x.Amount),
                    DonationsCount = group.Count()
                })
                .OrderByDescending(x => x.TotalAmount)
                .Take(count)
                .ToListAsync();

            return result;
        }

        public async Task<List<DonorReportDto>> GetDonorsByCountryAsync(string country)
        {
            var result = await _context.Donations
                .Include(d => d.Donor)
                .Where(d => d.Donor.Country == country)
                .GroupBy(d => d.DonorId)
                .Select(group => new DonorReportDto
                {
                    DonorId = group.Key,
                    DonorName = group.First().Donor.FullName,
                    Country = group.First().Donor.Country,
                    TotalAmount = group.Sum(x => x.Amount),
                    DonationsCount = group.Count()
                })
                .OrderByDescending(x => x.TotalAmount)
                .ToListAsync();

            return result;
        }

        public async Task<List<DonorDonationHistoryDto>> GetDonationsByDonorAsync(Guid donorId)
        {
            var donations = await _context.Donations
                .Where(d => d.DonorId == donorId)
                .OrderByDescending(d => d.DonationDate)
                .ProjectTo<DonorDonationHistoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return donations;
        }
    }
}
