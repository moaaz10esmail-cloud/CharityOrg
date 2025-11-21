using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVolunteerRepository
    {
        Task<List<Volunteer>> GetAllAsync();
        Task<Volunteer?> GetByIdAsync(int id);
        Task AddAsync(Volunteer volunteer);
        void Update(Volunteer volunteer);
        void Remove(Volunteer volunteer);
        Task<bool> ExistsAsync(int id);
        Task SaveChangesAsync();
    }
}