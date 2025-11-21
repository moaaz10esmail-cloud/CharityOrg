using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReportSchedule
    {
        public Guid Id { get; set; }
        public string ReportType { get; set; } = string.Empty; // e.g. Donor, Finance
        public string Format { get; set; } = "PDF"; // PDF or Excel
        public string CronExpression { get; set; } = string.Empty; // "0 9 * * *" daily at 9am
        public string? EmailTo { get; set; } // optional
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
