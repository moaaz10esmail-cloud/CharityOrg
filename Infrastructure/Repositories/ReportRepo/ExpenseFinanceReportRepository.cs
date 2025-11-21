using Application.GenericRepo.GenericRepo;
using Application.Interfaces.ReportInterfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReportRepo
{
    public class ExpenseFinanceReportRepository : GenericRepository<Expense>, IExpenseFinanceReportRepository
    {
        private readonly CharityDbContext _context;

        public ExpenseFinanceReportRepository(CharityDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalExpensesAsync(string currency)
        {
            return await _context.Expenses
                .Where(e => e.Currency == currency)
                .SumAsync(e => e.Amount);
        }

    }
}
