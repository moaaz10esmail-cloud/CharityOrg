using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Type { get; set; } = "Donation"; // Donation / Expense
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string? ReferenceId { get; set; } // link to Donation.Id or Expense.Id
        public string? Notes { get; set; }
    }
}
