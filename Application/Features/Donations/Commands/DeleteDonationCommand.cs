using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donations.Commands
{
    public class DeleteDonationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
