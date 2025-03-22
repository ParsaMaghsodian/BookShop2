using BookShop2.Application.DTO;
using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _db;
    public BookService(ApplicationDbContext db)
    {
        _db = db;
    }

    public void AddBook(BookCreateModel item)
    {
        _db.Books.Add(item.Adapt<BookData>()); // pass the info from our DTO to our DataModels which is BookData
        _db.SaveChanges();
    }

    public IList<BookItem> GetAllBooks()
    {
        // Manual projection
        //return _db.Books?.Select(x => new BookItem
        //{
        //    Id = x.Id,
        //    Name = x.Name,
        //    Description = x.Description,
        //    Pages = x.Pages,
        //    Price = x.Price,
        //    Author = x.Author,
        //    Date = x.Date,
        //}).ToList() ?? new List<BookItem>();

        // Automated Projection By Mapster
        return _db.Books.Include(c => c.BookCategory).ProjectToType<BookItem>().ToList();
    }

    public ICollection<BookCategory> GetAllCategories()
    {
        return _db.Categories.ToList();
    }

    public BookDetails GetBookDetails(int id)
    {
        return _db.Books.ProjectToType<BookDetails>().First(x => x.Id == id);
    }

    public BookEditModel GetEdit(int id)
    {

        return _db.Books.ProjectToType<BookEditModel>().First(x => x.Id == id);
    }

    public void Update(BookEditModel book)
    {
        _db.Books.Update(book.Adapt<BookData>());
        _db.SaveChanges();

    }
}
