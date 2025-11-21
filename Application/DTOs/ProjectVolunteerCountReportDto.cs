using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProjectVolunteerCountReportDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public int VolunteerCount { get; set; }
    }
}
