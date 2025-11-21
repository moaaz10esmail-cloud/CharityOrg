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
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly CharityDbContext _context;

        public BeneficiaryRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<Beneficiary> AddAsync(Beneficiary beneficiary)
        {
            _context.Beneficiaries.Add(beneficiary);
            await _context.SaveChangesAsync();
            return beneficiary;
        }

        public async Task<Beneficiary?> GetByIdAsync(Guid id)
        {
            return await _context.Beneficiaries.FindAsync(id);
        }

        public async Task<List<Beneficiary>> GetAllAsync()
        {
            return await _context.Beneficiaries.ToListAsync();
        }

        public async Task UpdateAsync(Beneficiary beneficiary)
        {
            _context.Beneficiaries.Update(beneficiary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary != null)
            {
                _context.Beneficiaries.Remove(beneficiary);
                await _context.SaveChangesAsync();
            }
        }
    }
}
