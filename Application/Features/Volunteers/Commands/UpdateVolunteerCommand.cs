using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Volunteers.Commands
{
    public class UpdateVolunteerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public string? Skills { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

}