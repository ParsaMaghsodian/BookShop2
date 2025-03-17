using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BookShop2.Web.Areas.Admin.Pages.Books;

public class CreateModel : PageModel
{
    [BindProperty]
    public BookDTO Book { get; set; }
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
        return RedirectToPage("./Index");
    }
}
