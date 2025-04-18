using BookShop2.Application;
using BookShop2.Application.DTO;
using BookShop2.Web.Areas.Admin.Pages.Books;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BookShop2.Web.Pages.Shop;

[Authorize]
public class ReviewModel : PageModel
{
    private readonly IBookService _bookService;
    private readonly IOrderService _orderService;
    public ReviewModel(IBookService bookService, IOrderService orderService)
    {
        _bookService = bookService;
        _orderService = orderService;
    }
    [BindProperty]
    public BookDetails Book { get; set; }
    public void OnGet(int bookid)
    {
        Book = _bookService.GetBookDetails(bookid);
    }
    public IActionResult OnPost()
    {
        var usercliam = User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = usercliam.Value;
        var orderId = _orderService.Add(new OrderCreateModel
        {
            Amount = Book.Price,
            BookId = Book.Id,
            UserId = userId,
        });
        _orderService.Confirm(orderId);
        TempData[Values.OrderId] = orderId;
        return RedirectToPage("./Receipt");
    }

}
