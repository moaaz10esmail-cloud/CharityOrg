using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RoleDistributionReportDto
    {
        public string Role { get; set; } = null!;
        public int Count { get; set; }
    }
}
