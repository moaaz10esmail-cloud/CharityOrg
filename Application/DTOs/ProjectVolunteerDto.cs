using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProjectVolunteerDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public int VolunteerId { get; set; }
        public string VolunteerName { get; set; } = null!;
        public string? Role { get; set; }
    }
}
