using BookShop2.Application;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Books;

public class DeleteModel : PageModel
{
    public RemoveBookViewModel Book { get; set; }
    private readonly IBookService _bookService;
    public DeleteModel(IBookService bookService)
    {
        _bookService = bookService;
    }
    public IActionResult OnPost(int id)
    {
        if (id != 0)
        {
            _bookService.RemoveBook(id);
            return RedirectToPage("./Index");
        }
        ModelState.AddModelError("", "Delete operation was not successful :(");
        return Page();
    }
    public void OnGet(int id)
    {
        Book = _bookService.GetRemove(id).Adapt<RemoveBookViewModel>();
    }
}
public class RemoveBookViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public byte[]? CoverImage { get; set; }
}
