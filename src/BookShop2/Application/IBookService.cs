using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application;

public interface IBookService
{
    IList<BookItem> GetAllBooks();
    void AddBook(BookCreateModel item);
}
