using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class DonationReportModuleDto
    {
        public Guid DonationId { get; set; }

        public string DonorName { get; set; } = string.Empty;

        public string BeneficiaryName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }


        public string DonorCountry { get; set; } = string.Empty;
    }
}
