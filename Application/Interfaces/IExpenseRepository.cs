using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense> AddAsync(Expense expense);
        Task<Expense?> GetByIdAsync(Guid id);
        Task<List<Expense>> GetAllAsync();
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(Guid id);
    }
}
