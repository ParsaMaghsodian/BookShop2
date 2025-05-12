using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Application.Mappers;
using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Services;

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

    public IList<BookItem> GetAllBooks(string term = "")
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
        if (string.IsNullOrEmpty(term))
        {
            // Automated Projection By Mapster
            return _db.Books.Include(c => c.BookCategory).ProjectToType<BookItem>().ToList();
        }
        else
        {
            return _db.Books.Where(b => b.Name.ToLower().StartsWith(term.ToLower()))
                .Include(c => c.BookCategory).ProjectToType<BookItem>().ToList();
        }

    }

    public ICollection<BookCategory> GetAllCategories()
    {
        return _db.Categories.ToList();
    }

    public BookDetails GetBookDetails(int id)
    {
        return _db.Books.Select(BookMapper.BookDetailsSelector).First(x => x.Id == id);
    }

    public BookEditModel GetEdit(int id)
    {

        return _db.Books.ProjectToType<BookEditModel>().First(x => x.Id == id);
    }

    public BookRemoveModel GetRemove(int id)
    {
        return _db.Books.ProjectToType<BookRemoveModel>().First(b => b.Id == id);
    }

    public void RemoveBook(int id)
    {
        var book = _db.Books.Find(id);
        if (book != null)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
        }
    }

    public void Update(BookEditModel book)
    {
        //// روش اول
        //_db.Books.Update(book.Adapt<BookData>());
        //_db.SaveChanges();

        //// روش دوم
        //var oldbook = _db.Books.Find(book.Id);
        //oldbook.Date = book.Date;
        //oldbook.Description = book.Description;
        //oldbook.Author = book.Author;
        //oldbook.Name = book.Name;
        //oldbook.CoverImage = book.CoverImage;
        //oldbook.CategoryId = book.CategoryId;
        //oldbook.Price = book.Price;
        //oldbook.Pages = book.Pages;
        //oldbook.Language = book.Language;
        //_db.SaveChanges();

        // روش سوم 

        var oldbook = _db.Books.Find(book.Id);
        _db.Entry(oldbook).CurrentValues.SetValues(book);
        _db.SaveChanges();

    }
}
