using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Mappers;

public static class BookMapper
{
    public static readonly Expression<Func<BookData, BookDetails>> BookDetailsSelector =
        book => new BookDetails
        {
            Name = book.Name,
            Description = book.Description,
            Author = book.Author,
            CoverImage = book.CoverImage,
            Date = book.Date,
            Pages = book.Pages,
            Price = book.Price,
            Id = book.Id,
            Language = book.Language.ToString(),
            RatingsScore = book.Ratings.Select(r=>(int)r.Score).ToList(),
            FileName = book.FileName
        };

}
