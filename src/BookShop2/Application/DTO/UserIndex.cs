using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class UserIndex
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string UserName { get; init; }
    public string? PhoneNumber { get; set; }
}
