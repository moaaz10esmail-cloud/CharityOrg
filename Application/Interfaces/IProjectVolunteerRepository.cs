using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectVolunteerRepository
    {
        Task<List<ProjectVolunteer>> GetByProjectIdAsync(int projectId);
        Task<List<ProjectVolunteer>> GetByVolunteerIdAsync(int volunteerId);
        Task<ProjectVolunteer?> GetByIdsAsync(int projectId, int volunteerId);
        Task AddAsync(ProjectVolunteer projectVolunteer);
        void Remove(ProjectVolunteer projectVolunteer);

        //  Reports
        Task<List<(int ProjectId, string ProjectName, int Count)>> GetVolunteerCountPerProjectAsync();
        Task<List<(string Role, int Count)>> GetRoleDistributionAsync();
        Task SaveChangesAsync();
    }
}
