using BookShop2.Application;
using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using System.ComponentModel.DataAnnotations;

namespace BookShop2.Web.Areas.Admin.Pages.Books;

public class EditModel : PageModel
{
    [BindProperty]
    public BookEditViewModel BookEdit { get; set; }
    public SelectList SelectListCategory { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    private readonly IBookService _bookService;
    public EditModel(IBookService bookService)
    {
        _bookService = bookService;
    }
    public void OnGet(int id)
    {
        var categories = _bookService.GetAllCategories();
        SelectListCategory = new SelectList(categories, "Id", "Name");
        BookEdit = _bookService.GetEdit(id).Adapt<BookEditViewModel>();

    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        // Check if a new cover image has been uploaded
        if (BookEdit.CoverImageUpload != null)
        {
            using MemoryStream ms = new MemoryStream();
            BookEdit.CoverImageUpload.CopyTo(ms);
            ms.Position = 0;
            BookEdit.CoverImage = ms.ToArray();
        }
        else
        {
            // Retain the existing image
            var existingBook = _bookService.GetEdit(BookEdit.Id);
            BookEdit.CoverImage = existingBook.CoverImage;
        }

        _bookService.Update(BookEdit.Adapt<BookEditModel>());
        StatusMessage = "The book has been Updated!";
        return RedirectToPage("./Index");
    }
}
public class BookEditViewModel
{
    public int Id { get; set; }
    [StringLength(40, ErrorMessage = "length must be between {2} and {1}.", MinimumLength = 2)]
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    public DateTime Date { get; set; }
    [Range(0, 1000, ErrorMessage = "Price must be between {1} and {2}")]
    public int Price { get; set; }
    [Range(0, 10000, ErrorMessage = "Pages must be between {1} and {2}")]
    public int Pages { get; set; }
    public byte[]? CoverImage { get; set; }
    public IFormFile? CoverImageUpload { get; set; }
    [Required(ErrorMessage = "Please Select a Language")]
    public Language Language { get; set; }
    [Required(ErrorMessage = "Please Select a Category")]
    public int CategoryId { get; set; }

}
