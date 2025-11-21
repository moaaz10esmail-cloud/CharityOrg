using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public string? Skills { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public ICollection<ProjectVolunteer> ProjectVolunteers { get; set; } = new List<ProjectVolunteer>();
    }
}