using Application.DTOs.ReportDTOs;
using Application.DTOs;
using Application.Features.Employees.Commands;
using Application.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    [Authorize(Roles = "Admin,SuperAdmin")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, new
            {
                message = "Employee added successfully",
                id = id
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            if (id != command.Id)
                return BadRequest("Employee ID mismatch.");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("Employee not found.");

            return Ok("Employee updated successfully.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok("Employee Deleted Successfully");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }


        [HttpGet("report")]
        public async Task<ActionResult<EmployeeReportDto>> GetReport()
        {
            return await _mediator.Send(new GetEmployeeReportQuery());
        }
    }
}
