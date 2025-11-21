using Application.Features.Donations.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donations.Handlers
{
    public class UpdateDonationCommandHandler : IRequestHandler<UpdateDonationCommand, bool>
    {
        private readonly IDonationRepository _repository;

        public UpdateDonationCommandHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetByIdAsync(request.Id);
            if (donation == null) return false;

            donation.Amount = request.Amount;
            donation.Currency = request.Currency;
            donation.DonationType = request.DonationType;
            donation.Notes = request.Notes;

            await _repository.UpdateAsync(donation);
            return true;
        }
    }
}