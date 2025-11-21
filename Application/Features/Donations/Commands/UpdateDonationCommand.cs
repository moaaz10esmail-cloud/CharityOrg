using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donations.Commands
{
    public class UpdateDonationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string? DonationType { get; set; }
        public string? Notes { get; set; }
    }
}
