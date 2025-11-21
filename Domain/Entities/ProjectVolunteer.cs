using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProjectVolunteer
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; } = null!;

        public string? Role { get; set; }
    }
}
