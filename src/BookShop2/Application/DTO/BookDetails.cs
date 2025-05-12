using BookShop2.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class BookDetails
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string? FileName { get; init; }
    public string? Description { get; init; }
    public string? Author { get; init; }
    public DateTime Date { get; init; }
    public int Price { get; init; }
    public int Pages { get; init; }
    public byte[]? CoverImage { get; init; }
    public string Language { get; init; }
    public double? AvgRating { get; init; }

}
