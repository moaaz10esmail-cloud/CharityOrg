using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expenses.Commands
{
    public class UpdateExpenseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string ExpenseCategory { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string? Description { get; set; }
        public string? IssuedBy { get; set; }
    }

}
