using BookShop2.Application;
using BookShop2.Application.DTO;
using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Books;

public class IndexModel : PageModel
{
    private readonly IBookService _bookService;
    public IndexModel(IBookService bookService)
    {
        _bookService = bookService;
    }
    public IList<BookItem>? BookList { get; set; }
    public void OnGet()
    {
        BookList = _bookService.GetAllBooks();
    }
}
