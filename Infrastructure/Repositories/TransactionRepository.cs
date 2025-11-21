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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly CharityDbContext _context;

        public TransactionRepository(CharityDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<List<Transaction>> GetAllAsync() =>
            await _context.Transactions.ToListAsync();

        public async Task<List<Transaction>> GetByDateRangeAsync(DateTime start, DateTime end) =>
            await _context.Transactions
                .Where(t => t.Date >= start && t.Date <= end)
                .ToListAsync();

        public async Task<decimal> GetBalanceAsync(string currency)
        {
            var donations = await _context.Transactions
                .Where(t => t.Type == "Donation" && t.Currency == currency)
                .SumAsync(t => t.Amount);

            var expenses = await _context.Transactions
                .Where(t => t.Type == "Expense" && t.Currency == currency)
                .SumAsync(t => t.Amount);

            return donations - expenses;
        }
    }
}
