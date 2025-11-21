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
    public class GetAllVolunteersQueryHandler : IRequestHandler<GetAllVolunteersQuery, List<VolunteerDto>>
    {
        private readonly IVolunteerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllVolunteersQueryHandler(IVolunteerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<VolunteerDto>> Handle(GetAllVolunteersQuery request, CancellationToken cancellationToken)
        {
            var volunteers = await _repository.GetAllAsync();
            return _mapper.Map<List<VolunteerDto>>(volunteers);
        }
    }
}