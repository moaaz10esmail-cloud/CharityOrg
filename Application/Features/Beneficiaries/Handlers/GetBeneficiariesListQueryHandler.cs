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
    public class GetBeneficiariesListQueryHandler : IRequestHandler<GetBeneficiariesListQuery, List<Beneficiary>>
    {
        private readonly IBeneficiaryRepository _repository;

        public GetBeneficiariesListQueryHandler(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Beneficiary>> Handle(GetBeneficiariesListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}