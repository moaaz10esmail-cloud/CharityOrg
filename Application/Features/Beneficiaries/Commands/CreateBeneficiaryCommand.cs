using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Beneficiaries.Commands
{
    public class CreateBeneficiaryCommand : IRequest<Beneficiary>
    {
        public string FullName { get; set; } = string.Empty;
        public string? NationalId { get; set; }
        public string? PhoneNumber { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Notes { get; set; }
    }
}
