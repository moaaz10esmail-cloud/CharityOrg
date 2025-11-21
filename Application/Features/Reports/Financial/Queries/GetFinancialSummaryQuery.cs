using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Financial.Queries
{
    public class GetFinancialSummaryQuery : IRequest<FinancialSummaryDto>
    {
        public string Currency { get; set; } = "USD";
    }
}
