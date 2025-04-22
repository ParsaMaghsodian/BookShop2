using BookShop2.Application;
using BookShop2.Application.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BookShop2.Web.Areas.Admin.Pages.Users;

public class IndexModel : PageModel
{
    private readonly IUserService _userService;
    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }
    public IEnumerable<UserIndex> UsersList { get; set; }
    public async Task OnGetAsync()
    {
        UsersList = await _userService.GetAllUsersAsync();
    }
}
