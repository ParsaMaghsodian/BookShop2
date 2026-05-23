using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;


namespace BookShop2.Application.Services;

public class ExcelService : IExcelService
{
    public byte[] CreateOrdersExcel(IEnumerable<OrderItems> orders)
    {
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Orders List");

        // Set Headers
        ws.Cell(1, 1).Value = "Order ID";
        ws.Cell(1, 2).Value = "User";
        ws.Cell(1, 3).Value = "Book Name";
        ws.Cell(1, 4).Value = "Total Amount";
        ws.Cell(1, 5).Value = "Order Date";

        // Style Headers (Bootstrap Primary Color #0d6efd)
        var headerRange = ws.Range(1, 1, 1, 5);
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Font.FontColor = XLColor.White;
        headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#0d6efd");
        headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        // Fill Data Rows
        int row = 2;
        foreach (var order in orders)
        {
            ws.Cell(row, 1).Value = order.OrderId;
            ws.Cell(row, 2).Value = order.UserUserName;
            ws.Cell(row, 3).Value = order.BookName;

            // Format Amount as currency
            ws.Cell(row, 4).Value = order.Amount;
            ws.Cell(row, 4).Style.NumberFormat.Format = "$#,##0.00";

            // Format Date
            ws.Cell(row, 5).Value = order.TimeCreation;
            ws.Cell(row, 5).Style.DateFormat.Format = "yyyy-MM-dd HH:mm";

            row++;
        }

        // Auto-fit columns to content for readability
        ws.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        wb.SaveAs(stream);
        return stream.ToArray();
    }
}
