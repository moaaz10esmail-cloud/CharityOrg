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
    public class ProjectVolunteerRepository : IProjectVolunteerRepository
    {
        private readonly CharityDbContext _context;

        public ProjectVolunteerRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectVolunteer>> GetByProjectIdAsync(int projectId)
        {
            return await _context.ProjectVolunteers
                .Include(pv => pv.Volunteer)
                .Include(pv => pv.Project)
                .Where(pv => pv.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<ProjectVolunteer>> GetByVolunteerIdAsync(int volunteerId)
        {
            return await _context.ProjectVolunteers
                .Include(pv => pv.Volunteer)
                .Include(pv => pv.Project)
                .Where(pv => pv.VolunteerId == volunteerId)
                .ToListAsync();
        }

        public async Task<ProjectVolunteer?> GetByIdsAsync(int projectId, int volunteerId)
        {
            return await _context.ProjectVolunteers
                .Include(pv => pv.Project)
                .Include(pv => pv.Volunteer)
                .FirstOrDefaultAsync(pv => pv.ProjectId == projectId && pv.VolunteerId == volunteerId);
        }

        public async Task AddAsync(ProjectVolunteer projectVolunteer)
            => await _context.ProjectVolunteers.AddAsync(projectVolunteer);

        public void Remove(ProjectVolunteer projectVolunteer)
            => _context.ProjectVolunteers.Remove(projectVolunteer);

        public async Task<List<(int ProjectId, string ProjectName, int Count)>> GetVolunteerCountPerProjectAsync()
        {
            return await _context.ProjectVolunteers
                .Include(pv => pv.Project)
                .GroupBy(pv => new { pv.ProjectId, pv.Project.Name })
                .Select(g => new ValueTuple<int, string, int>(g.Key.ProjectId, g.Key.Name, g.Count()))
                .ToListAsync();
        }

        public async Task<List<(string Role, int Count)>> GetRoleDistributionAsync()
        {
            return await _context.ProjectVolunteers
                .Where(pv => pv.Role != null && pv.Role != "")
                .GroupBy(pv => pv.Role!)
                .Select(g => new ValueTuple<string, int>(g.Key, g.Count()))
                .ToListAsync();
        }


        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }

}
