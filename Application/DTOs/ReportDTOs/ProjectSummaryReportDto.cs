using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class ProjectSummaryReportDto
    {
        public int TotalProjects { get; set; }
        public int OngoingProjects { get; set; }
        public int CompletedProjects { get; set; }
    }
}
