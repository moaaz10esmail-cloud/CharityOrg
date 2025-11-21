using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class DonorDonationHistoryDto
    {
        public Guid DonationId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string BeneficiaryName { get; set; } = string.Empty;
    }
}
