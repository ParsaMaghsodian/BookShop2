using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class BookItem
{
    public int Id { get; init; }
    public  string  Name { get; init; }
    public string ? Author { get; init; }
    public int Price { get; init; }
    public string BookCategoryName { get; init; }
}
