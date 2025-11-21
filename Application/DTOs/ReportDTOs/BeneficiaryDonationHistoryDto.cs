using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class BeneficiaryDonationHistoryDto
    {
        public Guid DonationId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string DonorName { get; set; } = string.Empty;
    }
}
