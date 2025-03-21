using BookShop2.Application;
using BookShop2.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Books;

public class BookDetailsModel : PageModel
{
    public BookDetails Details { get; set; }
    private readonly IBookService _bookService;
    public BookDetailsModel(IBookService bookService)
    {
        _bookService = bookService;
    }
    public void OnGet(int id)
    {
        Details = _bookService.GetBookDetails(id);
    }
}
