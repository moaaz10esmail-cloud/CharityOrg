using Application.Features.Expenses.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expenses.Handlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Expense>
    {
        private readonly IExpenseRepository _expenseRepo;
        private readonly ITransactionRepository _transactionRepo;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepo, ITransactionRepository transactionRepo)
        {
            _expenseRepo = expenseRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<Expense> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                ExpenseCategory = request.ExpenseCategory,
                Amount = request.Amount,
                Currency = request.Currency,
                Description = request.Description,
                IssuedBy = request.IssuedBy
            };

            var createdExpense = await _expenseRepo.AddAsync(expense);

            // سجل في Transactions للشفافية
            await _transactionRepo.AddAsync(new Transaction
            {
                Type = "Expense",
                Amount = createdExpense.Amount,
                Currency = createdExpense.Currency,
                ReferenceId = createdExpense.Id.ToString(),
                Notes = createdExpense.Description
            });

            return createdExpense;
        }
    }
}
