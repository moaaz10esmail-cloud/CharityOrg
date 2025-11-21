using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Application.Common.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Infrastructure.Services
{
    public class ReportExportService : IReportExportService
    {
        public byte[] ExportToPdf<T>(IEnumerable<T> data, string title)
        {
            var items = data.ToList();
            var props = typeof(T).GetProperties();

            var doc = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header().Text(title)
                        .FontSize(20)
                        .Bold()
                        .AlignCenter();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(cols =>
                        {
                            foreach (var _ in props)
                                cols.RelativeColumn();
                        });

                        // Header row
                        table.Header(header =>
                        {
                            foreach (var prop in props)
                            {
                                header.Cell().Element(cell =>
                                {
                                    cell.Background(Colors.Grey.Lighten2)
                                        .Padding(5)
                                        .AlignCenter()
                                        .Text(prop.Name).Bold();
                                });
                            }
                        });

                        // Data rows
                        foreach (var item in items)
                        {
                            table.Cell().ColumnSpan((uint)props.Length).Element(rowContainer =>
                            {
                                rowContainer.Row(row =>
                                {
                                    foreach (var prop in props)
                                    {
                                        var val = prop.GetValue(item)?.ToString() ?? "";
                                        row.RelativeColumn().Element(cell =>
                                        {
                                            cell.Padding(5).Text(val);
                                        });
                                    }
                                });
                            });
                        }

                    });
                });
            });

            return doc.GeneratePdf();
        }

        public byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add(sheetName);

            var items = data.ToList();
            var props = typeof(T).GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = props[i].Name;
            }

            for (int r = 0; r < items.Count; r++)
            {
                for (int c = 0; c < props.Length; c++)
                {
                    worksheet.Cells[r + 2, c + 1].Value = props[c].GetValue(items[r])?.ToString();
                }
            }

            return package.GetAsByteArray();
        }
    }
}
