using Application.Features.Beneficiaries.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Beneficiaries.Handlers
{
    public class CreateBeneficiaryCommandHandler : IRequestHandler<CreateBeneficiaryCommand, Beneficiary>
    {
        private readonly IBeneficiaryRepository _repository;

        public CreateBeneficiaryCommandHandler(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Beneficiary> Handle(CreateBeneficiaryCommand request, CancellationToken cancellationToken)
        {
            var beneficiary = new Beneficiary
            {
                FullName = request.FullName,
                NationalId = request.NationalId,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                Address = request.Address,
                Notes = request.Notes
            };

            return await _repository.AddAsync(beneficiary);
        }
    }
}