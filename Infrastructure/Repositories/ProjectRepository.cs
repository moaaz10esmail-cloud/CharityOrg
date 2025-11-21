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
    public class ProjectRepository : IProjectRepository
    {
        private readonly CharityDbContext _context;

        public ProjectRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync()
            => await _context.Projects.ToListAsync();

        public async Task<Project?> GetByIdAsync(int id)
            => await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Project project)
            => await _context.Projects.AddAsync(project);

        public void Update(Project project)
            => _context.Projects.Update(project);

        public void Remove(Project project)
            => _context.Projects.Remove(project);

        public async Task<bool> ExistsAsync(int id)
            => await _context.Projects.AnyAsync(p => p.Id == id);

        public async Task<List<(int ProjectId, string ProjectName, string Status)>> GetProjectStatusesAsync()
        {
            return await _context.Projects
                .Select(p => new ValueTuple<int, string, string>(
                    p.Id,
                    p.Name,
                    p.EndDate == null || p.EndDate > DateTime.UtcNow ? "Ongoing" : "Completed"
                ))
                .ToListAsync();
        }

        public async Task<List<(int ProjectId, string ProjectName, int DurationInDays)>> GetProjectDurationsAsync()
        {
            return await _context.Projects
                .Select(p => new ValueTuple<int, string, int>(
                    p.Id,
                    p.Name,
                    (p.EndDate ?? DateTime.UtcNow).Subtract(p.StartDate).Days
                ))
                .ToListAsync();
        }

        public async Task<(int Total, int Ongoing, int Completed)> GetProjectSummaryAsync()
        {
            var total = await _context.Projects.CountAsync();
            var ongoing = await _context.Projects.CountAsync(p => p.EndDate == null || p.EndDate > DateTime.UtcNow);
            var completed = await _context.Projects.CountAsync(p => p.EndDate != null && p.EndDate <= DateTime.UtcNow);

            return (total, ongoing, completed);
        }


        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }


}
