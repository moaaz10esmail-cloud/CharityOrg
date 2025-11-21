using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
