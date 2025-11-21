using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Volunteers.Commands
{
    public class DeleteVolunteerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
