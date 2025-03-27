using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class BookRemoveModel
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public int Price { get; init; }
    public byte[]? CoverImage { get; init; }
}

