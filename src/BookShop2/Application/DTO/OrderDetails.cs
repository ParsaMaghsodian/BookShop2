using BookShop2.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class OrderDetails
{
    public int OrderId { get; init; }
    public int Amount { get; init; }
    public string UserName { get; init; }
    public string BookName { get; init; }
    public string CategoryName { get; init; }
}
