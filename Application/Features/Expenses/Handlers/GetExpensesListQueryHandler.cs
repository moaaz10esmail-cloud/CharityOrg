using Application.Features.Expenses.Queries;
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
    public class GetExpensesListQueryHandler : IRequestHandler<GetExpensesListQuery, List<Expense>>
    {
        private readonly IExpenseRepository _expenseRepo;

        public GetExpensesListQueryHandler(IExpenseRepository expenseRepo)
        {
            _expenseRepo = expenseRepo;
        }

        public async Task<List<Expense>> Handle(GetExpensesListQuery request, CancellationToken cancellationToken)
        {
            return await _expenseRepo.GetAllAsync();
        }
    }
}
