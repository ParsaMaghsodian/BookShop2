using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    public async Task<bool> CreateFileAsync(IFormFile uploadedFile)
    {
        var rawFilename = Path.GetFileName(uploadedFile.FileName).Trim();
        var nameWithoutExtension = Path.GetFileNameWithoutExtension(rawFilename); // gets the file name only
        var extension = Path.GetExtension(rawFilename); // .pdf for instance
        // Replace 1 or more spaces with a single hyphen
        var cleanedName = Regex.Replace(nameWithoutExtension, @"\s+", "-");
        var finalFilename = cleanedName + extension;

        var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", finalFilename);
        if (System.IO.File.Exists(path))
            return false;

        using var stream = System.IO.File.Create(path);
        stream.Position = 0;
        await uploadedFile.CopyToAsync(stream);
        return true;
    }

    public bool DeleteFile(string filename)
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", filename);
        if (!File.Exists(filePath))
            return false;

        File.Delete(filePath);
        return true;
    }

    public IEnumerable<FileInfo> GetAllFiles()
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files");
        return new DirectoryInfo(filePath).GetFiles();
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
