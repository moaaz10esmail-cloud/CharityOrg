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
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly CharityDbContext _context;

        public VolunteerRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<List<Volunteer>> GetAllAsync()
        {
            return await _context.Volunteers.ToListAsync();
        }

        public async Task<Volunteer?> GetByIdAsync(int id)
        {
            return await _context.Volunteers.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Volunteer volunteer)
        {
            await _context.Volunteers.AddAsync(volunteer);
        }

        public void Update(Volunteer volunteer)
        {
            _context.Volunteers.Update(volunteer);
        }

        public void Remove(Volunteer volunteer)
        {
            _context.Volunteers.Remove(volunteer);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Volunteers.AnyAsync(v => v.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}