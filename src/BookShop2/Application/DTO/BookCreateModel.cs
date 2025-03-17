using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class BookCreateModel
{
    public string Name { get; init; }
    public string? Description { get; init; }
    public string? Author { get; init; }
    public DateTime Date { get; init; }
    public int Price { get; init; }
    public int Pages { get; init; }
}
