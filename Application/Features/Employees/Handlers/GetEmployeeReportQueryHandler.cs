using Application.DTOs;
using Application.DTOs.ReportDTOs;
using Application.Features.Employees.Queries;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Handlers
{
    public class GetEmployeeReportQueryHandler : IRequestHandler<GetEmployeeReportQuery, EmployeeReportDto>
    {
        private readonly IEmployeeRepository _repository;

        public GetEmployeeReportQueryHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeReportDto> Handle(GetEmployeeReportQuery request, CancellationToken cancellationToken)
        {
            var total = await _repository.GetTotalEmployeesAsync();
            var byPosition = await _repository.GetEmployeesByPositionAsync();

            return new EmployeeReportDto
            {
                TotalEmployees = total,
                EmployeesByPosition = byPosition
            };
        }
    }

}