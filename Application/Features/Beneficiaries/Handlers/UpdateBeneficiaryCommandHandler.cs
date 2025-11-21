using Application.Features.Beneficiaries.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Beneficiaries.Handlers
{
    public class UpdateBeneficiaryCommandHandler : IRequestHandler<UpdateBeneficiaryCommand, bool>
    {
        private readonly IBeneficiaryRepository _repository;

        public UpdateBeneficiaryCommandHandler(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBeneficiaryCommand request, CancellationToken cancellationToken)
        {
            var beneficiary = await _repository.GetByIdAsync(request.Id);
            if (beneficiary == null) return false;

            beneficiary.FullName = request.FullName;
            beneficiary.NationalId = request.NationalId;
            beneficiary.PhoneNumber = request.PhoneNumber;
            beneficiary.Country = request.Country;
            beneficiary.Address = request.Address;
            beneficiary.Notes = request.Notes;
            beneficiary.IsActive = request.IsActive;
            beneficiary.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(beneficiary);
            return true;
        }
    }
}
