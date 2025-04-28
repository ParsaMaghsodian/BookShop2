using BookShop2.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace BookShop2.Web.Areas.User.Pages;

public class IndexModel : PageModel
{
    public string? UserName { get; set; }
    public string UserId { get; set; } // for guid user 
    public void OnGet()
    {
        UserName = User.Identity!.Name;
        var userclaim = User.FindFirst(ClaimTypes.NameIdentifier); // gets the user claim from cookie
        UserId = userclaim!.Value; // get its Guid
    }
}
