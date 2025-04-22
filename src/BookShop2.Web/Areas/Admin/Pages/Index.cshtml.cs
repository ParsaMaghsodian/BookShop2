using BookShop2.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages;

 // [Authorize(Roles ="admin")]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
