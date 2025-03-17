using BookShop2.Application;
using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BookShop2.Web.Areas.Admin.Pages.Books;

public class CreateModel : PageModel
{
    private readonly IBookService _bookService;
    public CreateModel(IBookService bookService)
    {
        _bookService = bookService;
    }
    [BindProperty]
    public BookCreateViewModel Book { get; set; }
    public void OnGet()
    {
    }
    public IActionResult OnPost()
    {
        if (Book.Date > DateTime.Now || Book.Date.Year < 1990)
        {
            ModelState.AddModelError("Book.Date", $"The Date must be between {DateTime.Now.Year} and 1990!");  // Pass the key "" if you want ModelOnly Erorr
        }
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _bookService.AddBook(Book.Adapt<BookCreateModel>()); // Pass the info from our ViewModel to our DTO which is BookCreateModel
        return RedirectToPage("./Index");
    }
}

 // This class is just a ViewModel for validations
public class BookCreateViewModel 
{
    [StringLength(40, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    public DateTime Date { get; set; }
    [Range(0, 1000, ErrorMessage = "Price must be between {1} and {2}")]
    public int Price { get; set; }
    [Range(0, 10000, ErrorMessage = "Pages must be between {1} and {2}")]
    public int Pages { get; set; }

}