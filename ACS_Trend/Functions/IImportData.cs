using ACS_Trend.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;


namespace ACS_Trend.Functions
{
    public interface IImportData
    {
        List<Point> ImportPoints(IFormFile file);
    }

    public class ImportData_ : IImportData
    {
        public List<Point> ImportPoints(IFormFile file)
        {
            var pointslist = new List<Point>();

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;

                    for (int row = 2; row < rowcount; row++)
                    {
                        pointslist.Add(new Point
                        {
                            Date = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Parameter = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            ParameterOUT = worksheet.Cells[row, 3].Value.ToString().Trim()
                        });
                    }
                }
            }

            return pointslist;
        }
    }
}
