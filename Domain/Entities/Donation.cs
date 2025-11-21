using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Donation
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid DonorId { get; set; }
        public Donor Donor { get; set; }

        public Guid BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string? DonationType { get; set; } // Cash, In-kind, etc.

        public DateTime DonationDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}
