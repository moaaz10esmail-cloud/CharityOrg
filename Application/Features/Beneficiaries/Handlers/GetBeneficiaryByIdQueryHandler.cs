using Application.Features.Beneficiaries.Queries;
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
    public class GetBeneficiaryByIdQueryHandler : IRequestHandler<GetBeneficiaryByIdQuery, Beneficiary?>
    {
        private readonly IBeneficiaryRepository _repository;

        public GetBeneficiaryByIdQueryHandler(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Beneficiary?> Handle(GetBeneficiaryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
