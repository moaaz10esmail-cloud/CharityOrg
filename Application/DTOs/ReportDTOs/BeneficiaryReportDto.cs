using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class BeneficiaryReportDto
    {
        public Guid BeneficiaryId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int DonationsCount { get; set; }
        public decimal TotalReceived { get; set; }
    }
}
