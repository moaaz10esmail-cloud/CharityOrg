using Application.Features.Donations.Commands;
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
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, Donation>
    {
        private readonly IDonationRepository _repository;

        public CreateDonationCommandHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Donation> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = new Donation
            {
                DonorId = request.DonorId,
                BeneficiaryId = request.BeneficiaryId,
                Amount = request.Amount,
                Currency = request.Currency,
                DonationType = request.DonationType,
                Notes = request.Notes
            };

            return await _repository.AddAsync(donation);
        }
    }
}