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
    public class GetVolunteerCountPerProjectQueryHandler
     : IRequestHandler<GetVolunteerCountPerProjectQuery, List<ProjectVolunteerCountReportDto>>
    {
        private readonly IProjectVolunteerRepository _repository;
        private readonly IMapper _mapper;

        public GetVolunteerCountPerProjectQueryHandler(IProjectVolunteerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProjectVolunteerCountReportDto>> Handle(GetVolunteerCountPerProjectQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetVolunteerCountPerProjectAsync();
            return _mapper.Map<List<ProjectVolunteerCountReportDto>>(data);
        }
    }
}
