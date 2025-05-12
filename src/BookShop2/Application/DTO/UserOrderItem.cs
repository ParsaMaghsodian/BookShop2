using BookShop2.Infrastructure.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class UserOrderItem
{
    public int OrderId { get; init; }
    public int BookId { get; init; }
    public string BookName { get; init; }
    public DateTime TimeCreation { get; init; }
    public int Amount { get; init; }
    public RatingScore? RatingScore { get; init; }
}
