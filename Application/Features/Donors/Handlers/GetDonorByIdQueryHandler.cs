using Application.Features.Donors.Queries;
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
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, Donor?>
    {
        private readonly IDonorRepository _donorRepository;

        public GetDonorByIdQueryHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Donor?> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _donorRepository.GetByIdAsync(request.Id);
        }
    }
}
