using Application.Interfaces.ReportInterfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ReportRepo
{
   
    public class DonationReportRepository : IDonationReportRepository

    {

        private readonly CharityDbContext _context;

        public DonationReportRepository(CharityDbContext context)

        {

            _context = context;

        }

        public async Task<List<Donation>> GetDonationsByDateRangeAsync(DateTime startDate, DateTime endDate)

        {

            return await _context.Donations

              .Include(d => d.Donor)

              .Include(d => d.Beneficiary)

              .Where(d => d.DonationDate >= startDate && d.DonationDate <= endDate)

              .ToListAsync();

        }

        public async Task<List<Donation>> GetDonationsByCountryAsync(string country)

        {

            return await _context.Donations

              .Include(d => d.Donor)

              .Include(d => d.Beneficiary)

              .Where(d => d.Donor.Country == country)

              .ToListAsync();

        }
         
        public async Task<Donation?> GetDonationDetailsAsync(Guid donationId)

        {

            return await _context.Donations

              .Include(d => d.Donor)

              .Include(d => d.Beneficiary)

              .FirstOrDefaultAsync(d => d.Id == donationId);

        }

    }

}