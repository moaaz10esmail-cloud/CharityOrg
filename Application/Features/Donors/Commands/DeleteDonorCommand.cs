using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Donors.Commands
{
    public class DeleteDonorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
