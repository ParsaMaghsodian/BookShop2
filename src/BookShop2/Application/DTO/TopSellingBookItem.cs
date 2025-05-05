using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class TopSellingBookItem
{
    public int BookId { get; init; }
    public required string BookName { get; init; }
    public byte[]? CoverImage { get; init; }
    public int NumberOfSales { get; init; }
}
