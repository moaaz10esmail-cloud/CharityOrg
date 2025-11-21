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
    public class GetDonationsByBeneficiaryQueryHandler : IRequestHandler<GetDonationsByBeneficiaryQuery, List<Donation>>
    {
        private readonly IDonationRepository _repository;

        public GetDonationsByBeneficiaryQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Donation>> Handle(GetDonationsByBeneficiaryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByBeneficiaryIdAsync(request.BeneficiaryId);
        }
    }
}
