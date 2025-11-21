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
    public class GetProjectSummaryQueryHandler
     : IRequestHandler<GetProjectSummaryQuery, ProjectSummaryReportDto>
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public GetProjectSummaryQueryHandler(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProjectSummaryReportDto> Handle(GetProjectSummaryQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetProjectSummaryAsync();
            return _mapper.Map<ProjectSummaryReportDto>(data);
        }
    }
}