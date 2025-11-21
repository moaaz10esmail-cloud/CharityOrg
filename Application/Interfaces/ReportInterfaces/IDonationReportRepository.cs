using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReportInterfaces
{
    public interface IDonationReportRepository

    {

        Task<List<Donation>> GetDonationsByDateRangeAsync(DateTime startDate, DateTime endDate);

        Task<List<Donation>> GetDonationsByCountryAsync(string country);

        Task<Donation?> GetDonationDetailsAsync(Guid donationId);

    }

}