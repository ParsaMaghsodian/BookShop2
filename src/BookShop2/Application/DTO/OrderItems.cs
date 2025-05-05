using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class OrderItems
{
    public int OrderId { get; init; }
    public int Amount { get; init; }
    public string UserUserName { get; init; }
    public string BookName { get; init; }
    public DateTime TimeCreation { get; init; }
}
