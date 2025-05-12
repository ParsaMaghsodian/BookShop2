using BookShop2.Infrastructure.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.DataModels;

public class OrderData
{
    public int OrderId { get; set; }
    public RatingData? Rating { get; set; }
    public OrderState State { get; set; } // Enum 
    public int Amount { get; set; }
    public DateTime TimeCreation { get; set; }
    public int BookId { get; set; }
    public BookData Book { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
