using Application.Features.Employees.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
                return false;

            employee.FullName = request.FullName;
            employee.Position = request.Position;
            employee.Phone = request.Phone;
            employee.Email = request.Email;
            employee.HireDate = request.HireDate;
            employee.Salary = request.Salary;

            await _employeeRepository.UpdateAsync(employee);
            return true;
        }
    }
}
