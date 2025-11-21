using Application.DTOs;
using Application.Features.Volunteers.Queries;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Volunteers.Handlers
{
    public class GetVolunteerByIdQueryHandler : IRequestHandler<GetVolunteerByIdQuery, VolunteerDto>
    {
        private readonly IVolunteerRepository _repository;
        private readonly IMapper _mapper;

        public GetVolunteerByIdQueryHandler(IVolunteerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VolunteerDto> Handle(GetVolunteerByIdQuery request, CancellationToken cancellationToken)
        {
            var volunteer = await _repository.GetByIdAsync(request.Id);
            if (volunteer == null)
                throw new KeyNotFoundException("Volunteer not found");

            return _mapper.Map<VolunteerDto>(volunteer);
        }
    }
}