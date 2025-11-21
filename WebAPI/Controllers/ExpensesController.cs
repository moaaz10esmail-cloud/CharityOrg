using Application.Features.Expenses.Commands;
using Application.Features.Expenses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,SuperAdmin,Finance")]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Create Expense
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // Update Expense
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExpenseCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return Ok(new { Message = "Expense updated successfully" });
        }

        // Delete Expense
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteExpenseCommand { Id = id });
            if (!success) return NotFound();
            return Ok(new { Message = "Expense deleted successfully" });
        }

        // Get All Expenses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetExpensesListQuery());
            return Ok(result);
        }

        //  Get Expense by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetExpenseByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}