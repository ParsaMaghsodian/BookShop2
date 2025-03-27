using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.DataModels;

public class BookCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
