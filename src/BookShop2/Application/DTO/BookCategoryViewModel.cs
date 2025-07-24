using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class BookCategoryViewModel
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string OriginalName { get; init; }
    public bool IsChecked { get; init; }
}
