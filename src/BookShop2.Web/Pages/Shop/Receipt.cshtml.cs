using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Pages.Shop;

public class ReceiptModel : PageModel
{
    private readonly IOrderService _orderService;
    public ReceiptModel(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [BindProperty]
    public OrderDetails OrderDetails { get; set; }
    public void OnGet()
    {
        var tempOrderId = TempData[Values.OrderId];
        var OrderId = int.Parse(tempOrderId.ToString());
        OrderDetails = _orderService.GetOrder(OrderId);
    }
}
