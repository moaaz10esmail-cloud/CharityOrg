using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDonationRepository
    {
        Task<Donation> AddAsync(Donation donation);
        Task<Donation?> GetByIdAsync(Guid id);
        Task<List<Donation>> GetAllAsync();
        Task<List<Donation>> GetByDonorIdAsync(Guid donorId);
        Task<List<Donation>> GetByBeneficiaryIdAsync(Guid beneficiaryId);
        Task UpdateAsync(Donation donation);
        Task DeleteAsync(Guid id);
    }
}
