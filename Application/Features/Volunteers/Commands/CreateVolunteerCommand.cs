using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Volunteers.Commands
{
    public class CreateVolunteerCommand : IRequest<int>
    {
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public string? Skills { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

}