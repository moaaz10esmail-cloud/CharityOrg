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
    public class UpdateVolunteerCommandHandler : IRequestHandler<UpdateVolunteerCommand,Unit>
    {
        private readonly IVolunteerRepository _repository;

        public UpdateVolunteerCommandHandler(IVolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateVolunteerCommand request, CancellationToken cancellationToken)
        {
            var volunteer = await _repository.GetByIdAsync(request.Id);
            if (volunteer == null)
                throw new KeyNotFoundException("Volunteer not found");

            volunteer.FullName = request.FullName;
            volunteer.Age = request.Age;
            volunteer.Skills = request.Skills;
            volunteer.Phone = request.Phone;
            volunteer.Email = request.Email;

            _repository.Update(volunteer);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}