using Application.DTOs.ReportDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ReportInterfaces
{
    public interface IBeneficiaryReportRepository
    {
        Task<List<BeneficiaryReportDto>> GetAllBeneficiariesReportAsync();
        Task<List<BeneficiaryDonationHistoryDto>> GetDonationHistoryByBeneficiaryAsync(Guid beneficiaryId);

    }
}
