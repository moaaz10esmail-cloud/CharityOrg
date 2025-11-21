using Application.Features.Volunteers.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Volunteers.Handlers
{
    public class DeleteVolunteerCommandHandler : IRequestHandler<DeleteVolunteerCommand, bool>
    {
        private readonly IVolunteerRepository _repository;

        public DeleteVolunteerCommandHandler(IVolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteVolunteerCommand request, CancellationToken cancellationToken)
        {
            var volunteer = await _repository.GetByIdAsync(request.Id);
            if (volunteer == null)
                throw new KeyNotFoundException("Volunteer not found");

            _repository.Remove(volunteer);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}