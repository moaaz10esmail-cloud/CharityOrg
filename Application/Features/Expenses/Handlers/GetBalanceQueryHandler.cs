using Application.Features.Expenses.Transactions.Queries;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Expenses.Handlers
{
    public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, decimal>
    {
        private readonly ITransactionRepository _transactionRepo;

        public GetBalanceQueryHandler(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<decimal> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepo.GetBalanceAsync(request.Currency);
        }
    }
}
