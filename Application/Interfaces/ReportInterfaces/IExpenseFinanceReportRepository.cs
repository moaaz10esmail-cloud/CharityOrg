using Application.GenericRepo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReportInterfaces
{
    public interface IExpenseFinanceReportRepository : IGenericRepository<Expense>
    {
        Task<decimal> GetTotalExpensesAsync(string currency);
    }
}
