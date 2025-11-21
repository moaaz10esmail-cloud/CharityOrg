using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectVolunteers.Queries
{
    public class GetVolunteersByProjectQuery : IRequest<List<ProjectVolunteerDto>>
    {
        public int ProjectId { get; set; }
    }
}
