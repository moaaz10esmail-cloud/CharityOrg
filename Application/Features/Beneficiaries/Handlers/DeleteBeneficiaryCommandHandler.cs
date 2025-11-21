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
    public class DeleteBeneficiaryCommandHandler : IRequestHandler<DeleteBeneficiaryCommand, bool>
    {
        private readonly IBeneficiaryRepository _repository;

        public DeleteBeneficiaryCommandHandler(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBeneficiaryCommand request, CancellationToken cancellationToken)
        {
            var beneficiary = await _repository.GetByIdAsync(request.Id);
            if (beneficiary == null) return false;

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}