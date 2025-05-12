using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Services;

public class FileService : IFileService
{
    private readonly IOrderService _orderService;
    private readonly IBookService _bookService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileService(IOrderService orderService, IBookService bookService, IWebHostEnvironment webHostEnvironment)
    {
        _orderService = orderService;
        _bookService = bookService;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<(byte[] content, string fileName)?> GetFileByNameAsync(string fileName)
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", fileName);
        if (!File.Exists(filePath))
            return null;

        var content = await File.ReadAllBytesAsync(filePath);
        return (content, fileName);

    }

    public async Task<(byte[] content, string fileName)?> GetUserBookFileAsync(string userId, int bookId)
    {
        bool isAllowed = await _orderService.IsBoughtByThisUser(userId, bookId);
        var book = _bookService.GetBookDetails(bookId);
        if (!isAllowed || book.FileName is null)
            return null;
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", book.FileName);
        if (!File.Exists(filePath))
            return null;

        var content = await File.ReadAllBytesAsync(filePath);
        return (content, book.FileName);
    }
}
