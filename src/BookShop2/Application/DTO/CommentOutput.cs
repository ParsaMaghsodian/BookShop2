using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.DTO;

public class CommentOutput
{
    public required string Note { get; set; }
    public DateTime TimeCreation { get; set; }
    public required string UserName { get; set; }
}
