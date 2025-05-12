using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Web.Areas.Admin.Pages.Books;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
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
    public async Task<IActionResult> OnPostAsync()
    {
        var usercliam = User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = usercliam.Value;
        var result = await _orderService.IsBoughtByThisUser(userId, Book.Id);
        if (!result)
        {
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
        else
        {
            // ❗ Re-fetch book details from DB
            Book = _bookService.GetBookDetails(Book.Id);
            ModelState.AddModelError("", "This Book has already bought by this user :(");
            return Page();
        }

    }

}
