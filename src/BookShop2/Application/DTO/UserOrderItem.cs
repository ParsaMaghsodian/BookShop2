using BookShop2.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class UserOrderItem
{
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public string BookName { get; init; }
    public DateTime TimeCreation { get; init; }
    public int Amount { get; init; }
    public RatingScore? RatingScore { get; set; } // Goes to Orders entity => include with RatingData entity =>  Select Score by mapster 
}
