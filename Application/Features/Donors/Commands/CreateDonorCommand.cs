using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donors.Commands
{
    public class CreateDonorCommand : IRequest<Donor>
    {
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}
