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
    public class GetVolunteersByProjectQueryHandler : IRequestHandler<GetVolunteersByProjectQuery, List<ProjectVolunteerDto>>
    {
        private readonly IProjectVolunteerRepository _repository;
        private readonly IMapper _mapper;

        public GetVolunteersByProjectQueryHandler(IProjectVolunteerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProjectVolunteerDto>> Handle(GetVolunteersByProjectQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetByProjectIdAsync(request.ProjectId);
            return _mapper.Map<List<ProjectVolunteerDto>>(list);
        }
    }
}