using Application.DTOs.ReportDTOs;
using Application.Features.Projects.Queries;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Projects.Handlers
{
    public class GetProjectDurationsQueryHandler
      : IRequestHandler<GetProjectDurationsQuery, List<ProjectDurationReportDto>>
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public GetProjectDurationsQueryHandler(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProjectDurationReportDto>> Handle(GetProjectDurationsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetProjectDurationsAsync();
            return _mapper.Map<List<ProjectDurationReportDto>>(data);
        }
    }
}