using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddAsync(Transaction transaction);
        Task<List<Transaction>> GetAllAsync();
        Task<List<Transaction>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<decimal> GetBalanceAsync(string currency);
    }
}

