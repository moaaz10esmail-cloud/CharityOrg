using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expenses.Commands
{
    public class CreateExpenseCommand : IRequest<Expense>
    {
        public string ExpenseCategory { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string? Description { get; set; }
        public string? IssuedBy { get; set; }
    }
}
