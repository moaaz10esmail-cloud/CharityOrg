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
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, bool>
    {
        private readonly IDonorRepository _donorRepository;

        public DeleteDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<bool> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.Id);
            if (donor == null) return false;

            await _donorRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
