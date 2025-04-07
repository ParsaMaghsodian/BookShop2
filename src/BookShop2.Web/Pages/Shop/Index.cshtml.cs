using BookShop2.Application;
using BookShop2.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Pages.Shop;

public class IndexModel : PageModel
{
    private readonly IBookService _bookService;
    public IndexModel(IBookService bookService)
    {
        _bookService = bookService;
    }
    [BindProperty]
    public IEnumerable<BookItem> Books { get; set; }
    public void OnGet()
    {
        Books = _bookService.GetAllBooks();
    }
}
