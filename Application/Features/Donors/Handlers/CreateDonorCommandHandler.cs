using Application.Features.Donors.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donors.Handlers
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, Donor>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Donor> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                Address = request.Address
            };

            return await _donorRepository.AddAsync(donor);
        }
    }
}
