using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

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
    [BindProperty]
    public string? Term { get; set; }
    public void OnGet()
    {
        Books = _bookService.GetAllBooks();
    }
    public IActionResult OnPost()
    {
        Books = _bookService.GetAllBooks(Term);
        return Page();
    }
}
