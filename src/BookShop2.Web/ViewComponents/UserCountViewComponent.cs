using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop2.Web.ViewComponents;

public class UserCountViewComponent : ViewComponent
{
    private readonly IUserService _userService;
    public UserCountViewComponent(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        int counts = await _userService.GetUserCountAsync();
        return View("UsersCount", counts);
    }
}
