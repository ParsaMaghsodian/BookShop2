using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BookShop2.Web.Areas.User.Pages.Orders;
public class IndexModel : PageModel
{
    private readonly IOrderService _orderService;
    public IndexModel(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public IEnumerable<UserOrderItem> UserOrders { get; set; }
    public string UserName { get; set; }
    public async Task OnGetAsync()
    {
        UserName = User.GetUserName();
        UserOrders = await _orderService.GetAllOrdersByUserAsync(User.GetUserId());
    }
}
