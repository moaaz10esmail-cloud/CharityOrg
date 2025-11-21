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
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, bool>
    {
        private readonly IExpenseRepository _expenseRepo;

        public DeleteExpenseCommandHandler(IExpenseRepository expenseRepo)
        {
            _expenseRepo = expenseRepo;
        }

        public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepo.GetByIdAsync(request.Id);
            if (expense == null) return false;

            await _expenseRepo.DeleteAsync(request.Id);
            return true;
        }
    }
}