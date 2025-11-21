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
    public class GetProjectStatusesQueryHandler
     : IRequestHandler<GetProjectStatusesQuery, List<ProjectStatusReportDto>>
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public GetProjectStatusesQueryHandler(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProjectStatusReportDto>> Handle(GetProjectStatusesQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetProjectStatusesAsync();
            return _mapper.Map<List<ProjectStatusReportDto>>(data);
        }
    }
}
