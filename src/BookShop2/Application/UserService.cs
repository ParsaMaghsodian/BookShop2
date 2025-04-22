using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }


    public async Task<IEnumerable<UserIndex>> GetAllUsersAsync()
    {
        
        return await _userManager.Users.ProjectToType<UserIndex>().ToListAsync();
    }

    public async Task<int> GetUserCountAsync()
    {
        return await _userManager.Users.CountAsync();
    }
}
