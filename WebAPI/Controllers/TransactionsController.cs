using Application.Features.Expenses.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,SuperAdmin,Finance")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  Get All Transactions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetTransactionsListQuery());
            return Ok(result);
        }

        // Get Transactions by Date Range
        [HttpGet("range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var result = await _mediator.Send(new GetTransactionsByDateRangeQuery
            {
                StartDate = start,
                EndDate = end
            });
            return Ok(result);
        }

        //  Get Balance by Currency
        [HttpGet("balance/{currency}")]
        public async Task<IActionResult> GetBalance(string currency = "USD")
        {
            var result = await _mediator.Send(new GetBalanceQuery { Currency = currency });
            return Ok(new { Currency = currency, Balance = result });
        }
    }
}
