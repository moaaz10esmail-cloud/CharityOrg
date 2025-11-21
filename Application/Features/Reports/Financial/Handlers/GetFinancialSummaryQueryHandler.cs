using Application.DTOs;
using Application.Features.Reports.Financial.Queries;
using Application.Interfaces.ReportInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Financial.Handlers
{
    public class GetFinancialSummaryQueryHandler : IRequestHandler<GetFinancialSummaryQuery, FinancialSummaryDto>
    {
        private readonly IDonationFinanceReportRepository _donationRepo;
        private readonly IExpenseFinanceReportRepository _expenseRepo;

        public GetFinancialSummaryQueryHandler(IDonationFinanceReportRepository donationRepo, IExpenseFinanceReportRepository expenseRepo)
        {
            _donationRepo = donationRepo;
            _expenseRepo = expenseRepo;
        }

        public async Task<FinancialSummaryDto> Handle(GetFinancialSummaryQuery request, CancellationToken cancellationToken)
        {
            var totalDonations = await _donationRepo.GetTotalDonationsAsync(request.Currency);
            var totalExpenses = await _expenseRepo.GetTotalExpensesAsync(request.Currency);

            return new FinancialSummaryDto
            {
                TotalDonations = totalDonations,
                TotalExpenses = totalExpenses,
                Balance = totalDonations - totalExpenses
            };
        }
    }
}
