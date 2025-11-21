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
    public class GetDonationsByDonorQueryHandler : IRequestHandler<GetDonationsByDonorQuery, List<Donation>>
    {
        private readonly IDonationRepository _repository;

        public GetDonationsByDonorQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Donation>> Handle(GetDonationsByDonorQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByDonorIdAsync(request.DonorId);
        }
    }
}