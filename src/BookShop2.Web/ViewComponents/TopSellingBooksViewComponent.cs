using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop2.Web.ViewComponents;

public class TopSellingBooksViewComponent : ViewComponent
{
    private readonly IOrderService _orderService;
    public TopSellingBooksViewComponent(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<IViewComponentResult> InvokeAsync(int count = 3)
    {
        var topBooks = await _orderService.GetTopSellingBooksAsync(count);
        return View("TopSellingBooks", topBooks);
    }
}
