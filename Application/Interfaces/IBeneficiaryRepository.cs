using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBeneficiaryRepository
    {
        Task<Beneficiary> AddAsync(Beneficiary beneficiary);
        Task<Beneficiary?> GetByIdAsync(Guid id);
        Task<List<Beneficiary>> GetAllAsync();
        Task UpdateAsync(Beneficiary beneficiary);
        Task DeleteAsync(Guid id);
    }
}
