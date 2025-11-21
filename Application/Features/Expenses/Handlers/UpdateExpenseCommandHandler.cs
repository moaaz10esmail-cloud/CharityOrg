using Application.Features.Expenses.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expenses.Handlers
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, bool>
    {
        private readonly IExpenseRepository _expenseRepo;

        public UpdateExpenseCommandHandler(IExpenseRepository expenseRepo)
        {
            _expenseRepo = expenseRepo;
        }

        public async Task<bool> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepo.GetByIdAsync(request.Id);
            if (expense == null) return false;

            expense.ExpenseCategory = request.ExpenseCategory;
            expense.Amount = request.Amount;
            expense.Currency = request.Currency;
            expense.Description = request.Description;
            expense.IssuedBy = request.IssuedBy;

            await _expenseRepo.UpdateAsync(expense);
            return true;
        }
    }
}