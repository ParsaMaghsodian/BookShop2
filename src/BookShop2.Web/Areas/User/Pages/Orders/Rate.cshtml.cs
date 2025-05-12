using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Infrastructure.DataModels.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.User.Pages.Orders;

public class RateModel : PageModel
{
    private readonly IOrderService _orderService;
    private readonly IBookService _bookService;
    public RateModel(IOrderService orderService, IBookService bookService)
    {
        _orderService = orderService;
        _bookService = bookService;
    }
    [BindProperty]
    public int OrderId { get; set; }
    public BookDetails Book { get; set; }
    [BindProperty]
    public RatingScore Score { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    public void OnGet(int orderId, int bookId)
    {
        OrderId = orderId;
        Book = _bookService.GetBookDetails(bookId);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _orderService.AddRatingAsync(OrderId, Score);
        StatusMessage = "Thanks For Your Opinion";
        return RedirectToPage("./Index");
    }
}
