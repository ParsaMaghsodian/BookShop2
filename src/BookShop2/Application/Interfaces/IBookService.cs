using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Interfaces;

public interface IBookService
{
    IList<BookItem> GetAllBooks(string term = "");
    void AddBook(BookCreateModel item);
    BookDetails GetBookDetails(int id);
    BookEditModel GetEdit(int id);
    void Update(BookEditModel book);
    ICollection<BookCategory> GetAllCategories();
    void RemoveBook(int id);
    BookRemoveModel GetRemove(int id);
}
