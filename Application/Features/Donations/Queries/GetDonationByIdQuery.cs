using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donations.Queries
{
    public class GetDonationByIdQuery : IRequest<Donation?>
    {
        public Guid Id { get; set; }
    }
}
