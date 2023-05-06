using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDownload1.Controllers
{
    public class ImportExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload(IFormFile file)
        {
            var data = new List<string>();

            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var columnCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    var rowData = new StringBuilder();

                    for (int col = 1; col <= columnCount; col++)
                    {
                        var cellValue = worksheet.Cells[row, col].Value?.ToString() ?? string.Empty;
                        rowData.Append(cellValue);
                        rowData.Append(",");
                    }

                    data.Add(rowData.ToString().TrimEnd(','));
                }
            }

            ViewBag.Data = data;

            return View();
        }
    }
}
