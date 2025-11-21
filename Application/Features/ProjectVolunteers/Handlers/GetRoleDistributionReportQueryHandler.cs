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
    public class GetRoleDistributionReportQueryHandler
      : IRequestHandler<GetRoleDistributionReportQuery, List<RoleDistributionReportDto>>
    {
        private readonly IProjectVolunteerRepository _repository;
        private readonly IMapper _mapper;

        public GetRoleDistributionReportQueryHandler(IProjectVolunteerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RoleDistributionReportDto>> Handle(GetRoleDistributionReportQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetRoleDistributionAsync();
            return _mapper.Map<List<RoleDistributionReportDto>>(data);
        }
    }
}
