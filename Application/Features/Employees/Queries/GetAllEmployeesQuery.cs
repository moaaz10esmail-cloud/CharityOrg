using Application.DTOs;
using Application.DTOs.ReportDTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeDto>> { }
}


