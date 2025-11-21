using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDonorRepository
    {
        Task<Donor> AddAsync(Donor donor);
        Task<Donor?> GetByIdAsync(Guid id);
        Task<List<Donor>> GetAllAsync();
        Task UpdateAsync(Donor donor);
        Task DeleteAsync(Guid id);
    }
}
