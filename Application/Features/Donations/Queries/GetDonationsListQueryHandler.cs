using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donations.Queries
{
    public class GetDonationsListQueryHandler : IRequestHandler<GetDonationsListQuery, List<Donation>>
    {
        private readonly IDonationRepository _repository;

        public GetDonationsListQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Donation>> Handle(GetDonationsListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
