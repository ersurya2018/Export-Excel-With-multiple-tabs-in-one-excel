using ClosedXML.Excel;
using ExcelDownload1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExcelDownload1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //here we Export the single excel file
        public IActionResult Export()
        {
            try
            {
                var data = Employeedata();
                if(data!=null && data.Count>0)
                {
                    using(XLWorkbook wb=new XLWorkbook())
                    {
                        wb.Worksheets.Add(ToDataTable(data.ToList()));
                        using(MemoryStream strem=new MemoryStream())
                        {
                            wb.SaveAs(strem);
                            string filename = $"Customer_{DateTime.Now.ToString("dd/mm/yyyy")}.xlsx";
                            return File(strem.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheet.sheet", filename);
                        }
                    }
                }
                TempData["error"] = "Data not found";
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
        //This is Student list
        public List<Student> studentdata()
        {
            List<Student> data = new List<Student>()
            {
                new Student(){SID=1,Name="surya",Email="surya@gmail.com",Age=12,Phone="2345678"},
                new Student(){SID=2,Name="prajapati",Email="pra@gmail.com",Age=12,Phone="234567"},
                new Student(){SID=3,Name="dj",Email="dj@gmail.com",Age=22,Phone="4345678"},
                new Student(){SID=4,Name="singh",Email="singh@gmail.com",Age=42,Phone="23678"},
            };
            return data;
            
        }
        //This is Employee list
        public List<Employee> Employeedata()
        {
            List<Employee> data = new List<Employee>()
            {
                new Employee(){EmpId=1,Name="hello"},
                new Employee(){EmpId=2,Name="mohan"},
                new Employee(){EmpId=3,Name="how"},
                new Employee(){EmpId=4,Name="are you"},
            };
            return data;

        }
        //Here we convert the list data in datatable 
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        //using this section Export excel with multipule tabs in single file by using the static data
        public IActionResult ExportExcelMuSheet()
        {
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the Excel package
                var sheet1 = package.Workbook.Worksheets.Add("Student");
                var sheet2 = package.Workbook.Worksheets.Add("Employee");

                // Add data to the worksheets
                var SData = studentdata();
                var tabledata=ToDataTable(SData.ToList());
                var EData = Employeedata();

                sheet1.Cells["A1"].Value = "Name";
                sheet1.Cells["B1"].Value = "Age";
                sheet1.Cells["A2"].Value = "John";
                sheet1.Cells["B2"].Value = 30;
                sheet1.Cells["A3"].Value = "Jane";
                sheet1.Cells["B3"].Value = 25;


                sheet2.Cells["A1"].Value = "Product";
                sheet2.Cells["B1"].Value = "Price";
                sheet2.Cells["A2"].Value = "Apple";
                sheet2.Cells["B2"].Value = 1.2;
                sheet2.Cells["A3"].Value = "Banana";
                sheet2.Cells["B3"].Value = 0.8;


                //sheet1.SetValue = tabledata;
                //sheet1.Cells[1, 1].Value = tabledata;
                //foreach (var item in SData)
                //{
                //    foreach
                //}
                //for (int i = 0; i < EData.Count; i++)
                //{
                //    for (int j = 0; j < EData[0].; j++)
                //    {
                //        sheet1.Cells[i, j].Value = SData[j];
                //    }
                //}
                //sheet1.Cells[1, 1].Value = SData;
                //sheet2.Cells[1, 1].Value = EData;

                // Save the Excel package to a stream
                var stream = new MemoryStream();
                package.SaveAs(stream);

                // Download the Excel file
                stream.Position = 0;
                var fileName = "MyExcelFile.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
        //This is the final Export Excel with multipule tabs in the singale excel file with the database. 
        public IActionResult ExportExcelMuSheet2()
        {
            var Studentdata = studentdata().ToList();
            var Empdata = Employeedata().ToList();

            var package = new ExcelPackage();
            var StudentSheet = package.Workbook.Worksheets.Add("Greviance with policy no.");
            var EmpSheet = package.Workbook.Worksheets.Add("Greviance without policy no.");
            // Populate each sheet with data
            StudentSheet.Cells["A1"].LoadFromCollection(Studentdata, true);
            EmpSheet.Cells["A1"].LoadFromCollection(Empdata, true);

            // Save the Excel file
            byte[] excelBytes = package.GetAsByteArray();
            string filename = $"Customer_{DateTime.Now.ToString("dd/mm/yyyy")}.xlsx";
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "mydata.xlsx");
        }
    }
}
