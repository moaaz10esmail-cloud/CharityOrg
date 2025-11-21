using Application.Features.Expenses.Transactions.Queries;
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
    public class GetTransactionsByDateRangeQueryHandler : IRequestHandler<GetTransactionsByDateRangeQuery, List<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepo;

        public GetTransactionsByDateRangeQueryHandler(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<List<Transaction>> Handle(GetTransactionsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepo.GetByDateRangeAsync(request.StartDate, request.EndDate);
        }
    }
}


