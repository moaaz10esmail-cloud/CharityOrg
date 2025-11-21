using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FullName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime HireDate { get; set; }
        public decimal? Salary { get; set; }
    }
}
