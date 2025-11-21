using Application.GenericRepo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReportInterfaces
{
    public interface IDonationFinanceReportRepository : IGenericRepository<Donation>
    {
        Task<decimal> GetTotalDonationsAsync(string currency);
        Task<List<Donation>> GetDonationsByDateRangeAsync(DateTime start, DateTime end);
    }
}
