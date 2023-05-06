using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelDownload1.Models
{
    public class ExcelData
    {
        public string SheetName { get; set; }
        public List<RowData> Rows { get; set; }
    }
}
