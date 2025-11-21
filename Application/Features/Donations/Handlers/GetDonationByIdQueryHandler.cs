using Application.Features.Donations.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donations.Handlers
{
    public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, Donation?>
    {
        private readonly IDonationRepository _repository;

        public GetDonationByIdQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Donation?> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
