using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class ReportScheduleDto
    {
        public string ReportType { get; set; } = string.Empty;
        public string Format { get; set; } = "PDF";
        public string CronExpression { get; set; } = string.Empty;
        public string? EmailTo { get; set; }
    }
}
