using Application.DTOs.ReportDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReportInterfaces
{
    public interface IDonorReportRepository
    {
        Task<List<DonorReportDto>> GetTopDonorsAsync(int count);
        Task<List<DonorReportDto>> GetDonorsByCountryAsync(string country);
        Task<List<DonorDonationHistoryDto>> GetDonationsByDonorAsync(Guid donorId);
    }
}
