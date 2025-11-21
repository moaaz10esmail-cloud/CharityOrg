using Application.DTOs;
using Application.Features.ProjectVolunteers.Queries;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectVolunteers.Handlers
{
    public class GetProjectsByVolunteerQueryHandler : IRequestHandler<GetProjectsByVolunteerQuery, List<ProjectVolunteerDto>>
    {
        private readonly IProjectVolunteerRepository _repository;
        private readonly IMapper _mapper;

        public GetProjectsByVolunteerQueryHandler(IProjectVolunteerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProjectVolunteerDto>> Handle(GetProjectsByVolunteerQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetByVolunteerIdAsync(request.VolunteerId);
            return _mapper.Map<List<ProjectVolunteerDto>>(list);
        }
    }
}
