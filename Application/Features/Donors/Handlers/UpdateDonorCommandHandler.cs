using Application.Features.Donors.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donors.Handlers
{
    public class UpdateDonorCommandHandler : IRequestHandler<UpdateDonorCommand, bool>
    {
        private readonly IDonorRepository _donorRepository;

        public UpdateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<bool> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);
            if (donor == null) return false;

            donor.FullName = request.FullName;
            donor.Email = request.Email;
            donor.PhoneNumber = request.PhoneNumber;
            donor.Country = request.Country;
            donor.Address = request.Address;
            donor.IsActive = request.IsActive;
            donor.UpdatedAt = DateTime.UtcNow;

            await _donorRepository.UpdateAsync(donor);
            return true;
        }
    }
}
