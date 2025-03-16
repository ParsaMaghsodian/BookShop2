using BookShop2.Infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Books;

public class CreateModel : PageModel
{
    public BookData Book { get; set; }
    public void OnGet()
    {
    }
    public void OnPost()
    {
    }
}
