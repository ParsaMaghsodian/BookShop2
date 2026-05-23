using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Orders;

public class IndexModel : PageModel
{
    private readonly IOrderService _orderService;
    public IndexModel(IOrderService orderService)
    {
            _orderService = orderService;
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
}
