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
    public class DonorRepository : IDonorRepository
    {
        private readonly CharityDbContext _context;

        public DonorRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<Donor> AddAsync(Donor donor)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();
            return donor;
        }

        public async Task<Donor?> GetByIdAsync(Guid id)
        {
            return await _context.Donors.FindAsync(id);
        }

        public async Task<List<Donor>> GetAllAsync()
        {
            return await _context.Donors.ToListAsync();
        }

        public async Task UpdateAsync(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
