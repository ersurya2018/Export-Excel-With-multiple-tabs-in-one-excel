#pragma checksum "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\ImportExcel\ImportExcel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff0bb2e0aecb564c74a7b760da3845a7e964dabf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImportExcel_ImportExcel), @"mvc.1.0.view", @"/Views/ImportExcel/ImportExcel.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\_ViewImports.cshtml"
using ExcelDownload1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\_ViewImports.cshtml"
using ExcelDownload1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff0bb2e0aecb564c74a7b760da3845a7e964dabf", @"/Views/ImportExcel/ImportExcel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da6691688eacd775f32df09f3ea56689bb19c53", @"/Views/_ViewImports.cshtml")]
    public class Views_ImportExcel_ImportExcel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ExcelData>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table border=\"1\">\r\n    <thead>\r\n        <tr>\r\n            <th>Sheet Name</th>\r\n            <th>Column 1</th>\r\n            <th>Column 2</th>\r\n            <!-- add more headers as needed -->\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 13 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\ImportExcel\ImportExcel.cshtml"
         foreach (var sheet in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 16 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\ImportExcel\ImportExcel.cshtml"
               Write(sheet.SheetName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td></td>\r\n                <td></td>\r\n                <!-- add more cells as needed -->\r\n            </tr>\r\n");
#nullable restore
#line 21 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\ImportExcel\ImportExcel.cshtml"
            foreach (var row in sheet.Rows)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td>");
#nullable restore
#line 25 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\ImportExcel\ImportExcel.cshtml"
                   Write(row.SID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\ImportExcel\ImportExcel.cshtml"
                   Write(row.SName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <!-- add more cells as needed -->\r\n                </tr>\r\n");
#nullable restore
#line 29 "D:\SelfProject\Export-Excel-With-multiple-tabs-in-one-excel\ExcelDownload1\Views\ImportExcel\ImportExcel.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ExcelData>> Html { get; private set; }
    }
}
#pragma warning restore 1591
