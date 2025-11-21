using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{

    public class DonationRepository : IDonationRepository
    {
        private readonly CharityDbContext _context;

        public DonationRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<Donation> AddAsync(Donation donation)
        {
            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();
            return donation;
        }

        public async Task<Donation?> GetByIdAsync(Guid id)
        {
            return await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Beneficiary)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Donation>> GetAllAsync()
        {
            return await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Beneficiary)
                .ToListAsync();
        }

        public async Task<List<Donation>> GetByDonorIdAsync(Guid donorId)
        {
            return await _context.Donations
                .Include(d => d.Beneficiary)
                .Where(d => d.DonorId == donorId)
                .ToListAsync();
        }

        public async Task<List<Donation>> GetByBeneficiaryIdAsync(Guid beneficiaryId)
        {
            return await _context.Donations
                .Include(d => d.Donor)
                .Where(d => d.BeneficiaryId == beneficiaryId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Donation donation)
        {
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
                await _context.SaveChangesAsync();
            }
        }
    }
}

