using Application.GenericRepo.GenericRepo;
using Application.Interfaces.ReportInterfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReportRepo
{
    public class DonationFinanceReportRepository : GenericRepository<Donation>, IDonationFinanceReportRepository
    {
        private readonly CharityDbContext _context;

        public DonationFinanceReportRepository(CharityDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalDonationsAsync(string currency)
        {
            return await _context.Donations
                .Where(d => d.Currency == currency)
                .SumAsync(d => d.Amount);
        }

        public async Task<List<Donation>> GetDonationsByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.Donations
                .Where(d => d.DonationDate >= start && d.DonationDate <= end)
                .ToListAsync();
        }
    }
}
