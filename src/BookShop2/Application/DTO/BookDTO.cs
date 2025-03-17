using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class BookDTO
{
    public int Id { get; set; }
    [StringLength(40, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
    [Required]
    public  string  Name { get; set; }
    public string ? Description { get; set; }
    public string ? Author { get; set; }
    public DateTime Date { get; set; }
    [Range(0, 1000, ErrorMessage = "Price must be between {1} and {2}")]
    public int Price { get; set; }
    [Range(0, 10000, ErrorMessage = "Pages must be between {1} and {2}")]
    public int Pages { get; set; }
}
