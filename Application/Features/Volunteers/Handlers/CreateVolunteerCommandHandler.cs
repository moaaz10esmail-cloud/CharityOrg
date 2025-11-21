using Application.Features.Volunteers.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Volunteers.Handlers
{
    public class CreateVolunteerCommandHandler : IRequestHandler<CreateVolunteerCommand, int>
    {
        private readonly IVolunteerRepository _repository;

        public CreateVolunteerCommandHandler(IVolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateVolunteerCommand request, CancellationToken cancellationToken)
        {
            var volunteer = new Volunteer
            {
                FullName = request.FullName,
                Age = request.Age,
                Skills = request.Skills,
                Phone = request.Phone,
                Email = request.Email
            };

            await _repository.AddAsync(volunteer);
            await _repository.SaveChangesAsync();

            return volunteer.Id;
        }
    }
}