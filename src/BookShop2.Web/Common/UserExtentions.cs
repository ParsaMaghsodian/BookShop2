using System.Security.Claims;

namespace BookShop2.Web.Common;

public static class UserExtentions
{
    public static string GetUserId(this ClaimsPrincipal user)
    {
        if (user is not null && user.Identity is not null && user.Identity.IsAuthenticated)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId is not null ? userId : string.Empty;
        }
        return string.Empty;
    }
    public static string GetUserName(this ClaimsPrincipal user)
    {
        if (user is not null && user.Identity is not null && user.Identity.IsAuthenticated)
        {
            return user.Identity.Name;
        }
         return string.Empty;
    }
}
