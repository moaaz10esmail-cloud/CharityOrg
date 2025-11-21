using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donations.Handlers
{
    public class GetDonationsByDonorQuery : IRequest<List<Donation>>
    {
        public Guid DonorId { get; set; }
    }
}