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
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, Expense?>
    {
        private readonly IExpenseRepository _expenseRepo;

        public GetExpenseByIdQueryHandler(IExpenseRepository expenseRepo)
        {
            _expenseRepo = expenseRepo;
        }

        public async Task<Expense?> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _expenseRepo.GetByIdAsync(request.Id);
        }
    }
}