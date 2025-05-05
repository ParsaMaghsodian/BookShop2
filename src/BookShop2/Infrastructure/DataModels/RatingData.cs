using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.DataModels;

public class RatingData
{
    public int BookId { get; set; }
    public BookData Book { get; set; }
    public int OrderId { get; set; }
    public OrderData Order { get; set; }
    public DateTime TimeCreation { get; set; }
    public RatingScore Score { get; set; }
}
