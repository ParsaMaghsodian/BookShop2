using BookShop2.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class OrderCreateModel
{
    public int Amount { get; init; }
    public int BookId { get; init; }
    public string UserId { get; init; }
}
