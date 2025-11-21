using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class DonorReportDto
    {
        public Guid DonorId { get; set; }
        public string DonorName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public int DonationsCount { get; set; }
    }
}
