using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ExpenseCategory { get; set; } = string.Empty; // Rent, Salary, Project, etc.
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public DateTime ExpenseDate { get; set; } = DateTime.UtcNow;
        public string? Description { get; set; }

        public string? IssuedBy { get; set; }
    }
}
