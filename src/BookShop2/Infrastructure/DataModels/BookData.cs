using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.DataModels;

public class BookData
{
    public int Id { get; set; }
    public ICollection<RatingData> Ratings { get; set; }
    public required string Name { get; set; }
    public string? FileName { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }
    public DateTime Date { get; set; }
    public int Price { get; set; }
    public int Pages { get; set; }
    public byte[]? CoverImage { get; set; }
    public Language Language { get; set; }
    public int CategoryId { get; set; }
    public BookCategory BookCategory { get; set; }
}
