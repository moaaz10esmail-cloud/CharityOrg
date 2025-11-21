using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReportDTOs
{
    public class EmployeeReportDto
    {
        public int TotalEmployees { get; set; }
        public Dictionary<string, int> EmployeesByPosition { get; set; } = new();
    }
}
