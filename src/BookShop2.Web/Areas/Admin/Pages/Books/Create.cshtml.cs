using BookShop2.Application;
using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
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
    public SelectList SelectListCategory { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    public void OnGet()
    {
        var categories = _bookService.GetAllCategories();
        SelectListCategory = new SelectList(categories, "Id", "Name");
    }
    public IActionResult OnPost()
    {
        // Validate the Date
        if (Book.Date > DateTime.Now || Book.Date.Year < 1990)
        {
            ModelState.AddModelError("Book.Date", $"The Date must be between {DateTime.Now.Year} and 1990!");  // Pass the key "" if you want ModelOnly Erorr
        }
        // 1MB limit in uploading 
        if (Book.CoverImage != null && Book.CoverImage.Length > 1_000_000)
        {
            ModelState.AddModelError("Book.CoverImage", "Cover image must not exceed 1 MB.");
        }
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Process CoverImage only if it's not null
        if (Book.CoverImage != null)
        {
            using MemoryStream ms = new MemoryStream();
            Book.CoverImage.CopyTo(ms);
            ms.Position = 0;
            Book.CoverImageData = ms.ToArray();
        }


        _bookService.AddBook(new BookCreateModel   // Pass the info from our ViewModel to our DTO which is BookCreateModel
        {
            CoverImage = Book.CoverImageData, // Pass null if no image is provided
            Name = Book.Name,
            Description = Book.Description,
            Author = Book.Author,
            Date = Book.Date,
            Price = Book.Price,
            Pages = Book.Pages,
            Language = Book.Language,
            CategoryId = Book.CategoryId,
            FileName = Book.FileName
        });
        StatusMessage = "The Book has been Created!";
        return RedirectToPage("./Index");
    }
}

// This class is just a ViewModel for validations
public class BookCreateViewModel
{
    [StringLength(40, ErrorMessage = "length must be between {2} and {1}.", MinimumLength = 2)]
    [Required]
    public string Name { get; set; }
    public string ? FileName { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    public DateTime Date { get; set; }
    [Range(0, 1000, ErrorMessage = "Price must be between {1} and {2}")]
    public int Price { get; set; }
    [Range(0, 10000, ErrorMessage = "Pages must be between {1} and {2}")]
    public int Pages { get; set; }
    public IFormFile? CoverImage { get; set; }
    public byte[]? CoverImageData { get; set; } = null;
    [Required(ErrorMessage = "Please Select a Language")]
    public Language Language { get; set; }
    [Required(ErrorMessage = "Please Select a Category")]
    public int CategoryId { get; set; }
}