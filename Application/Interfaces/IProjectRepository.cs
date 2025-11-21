using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task AddAsync(Project project);
        void Update(Project project);
        void Remove(Project project);
        Task<bool> ExistsAsync(int id);
        Task<List<(int ProjectId, string ProjectName, string Status)>> GetProjectStatusesAsync();
        Task<List<(int ProjectId, string ProjectName, int DurationInDays)>> GetProjectDurationsAsync();
        Task<(int Total, int Ongoing, int Completed)> GetProjectSummaryAsync();

        Task SaveChangesAsync();
    }
}
