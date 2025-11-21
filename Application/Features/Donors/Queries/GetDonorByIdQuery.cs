using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donors.Queries
{
    public class GetDonorByIdQuery : IRequest<Donor?>
    {
        public Guid Id { get; set; }
    }
}
