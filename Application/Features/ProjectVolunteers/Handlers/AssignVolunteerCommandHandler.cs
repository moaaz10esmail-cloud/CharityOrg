using Application.Features.ProjectVolunteers.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectVolunteers.Handlers
{
    public class AssignVolunteerCommandHandler : IRequestHandler<AssignVolunteerCommand, Unit>
    {
        private readonly IProjectVolunteerRepository _repository;

        public AssignVolunteerCommandHandler(IProjectVolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AssignVolunteerCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdsAsync(request.ProjectId, request.VolunteerId);
            if (existing != null)
                throw new InvalidOperationException("Volunteer already assigned to this project");

            var pv = new ProjectVolunteer
            {
                ProjectId = request.ProjectId,
                VolunteerId = request.VolunteerId,
                Role = request.Role
            };

            await _repository.AddAsync(pv);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}