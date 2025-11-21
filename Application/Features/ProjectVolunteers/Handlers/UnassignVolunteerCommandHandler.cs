using Application.Features.ProjectVolunteers.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectVolunteers.Handlers
{
    public class UnassignVolunteerCommandHandler : IRequestHandler<UnassignVolunteerCommand,Unit>
    {
        private readonly IProjectVolunteerRepository _repository;

        public UnassignVolunteerCommandHandler(IProjectVolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UnassignVolunteerCommand request, CancellationToken cancellationToken)
        {
            var pv = await _repository.GetByIdsAsync(request.ProjectId, request.VolunteerId);
            if (pv == null)
                throw new KeyNotFoundException("Assignment not found");

            _repository.Remove(pv);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
