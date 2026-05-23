using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Orders;

public class IndexModel : PageModel
{
    private readonly IOrderService _orderService;
    private readonly IExcelService _excelService;
    public IndexModel(IOrderService orderService, IExcelService excelService)
    {
        _orderService = orderService;
        _excelService = excelService;
    }
    public IEnumerable<OrderItems> OrdersList { get; set; } = Enumerable.Empty<OrderItems>();
    [BindProperty(SupportsGet = true)]
    public string? UserName { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? BookName { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateTime? FromDate { get; set; }
    [BindProperty(SupportsGet = true)]
    public DateTime? ToDate { get; set; }
    public async Task OnGetAsync()
    {
        OrdersList = await _orderService.GetFilteredOrdersAsync(UserName, FromDate, ToDate, BookName);
    }
    public async Task<IActionResult> OnGetExportAsync()
    {
        // 1. Get filtered data
        var orders = await _orderService.GetFilteredOrdersAsync(UserName, FromDate, ToDate, BookName);

        // 2. Delegate the generation task to ExcelService
        byte[] fileContents = _excelService.CreateOrdersExcel(orders);

        // 3. Return the file stream
        var fileName = $"Orders_Export_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        return File(
            fileContents,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileName
        );
    }
}
