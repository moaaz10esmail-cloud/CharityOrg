using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectVolunteers.Commands
{
    public class AssignVolunteerCommand : IRequest<Unit>
    {
        public int ProjectId { get; set; }
        public int VolunteerId { get; set; }
        public string? Role { get; set; }
    }
}
