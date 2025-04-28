using BookShop2.Application;
using Microsoft.AspNetCore.Mvc;

namespace BookShop2.Web.Controllers;

[Route("[controller]/[action]")]
public class FilesController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IBookService _bookService;
    public FilesController(IWebHostEnvironment webHostEnvironment, IBookService bookService)
    {
        _webHostEnvironment = webHostEnvironment;
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult Download(string filename)
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", filename);
        if (System.IO.File.Exists(filePath))
        {
            var content = System.IO.File.ReadAllBytes(filePath);
            return File(content, "aplication/pdf", filename);
        }
        else
        {
            return NotFound($"The file '{filename}' does not exist.");
        }

    }
    //[HttpGet]
    //public IActionResult Download(int bookId)
    //{
    //    var book = _bookService.GetBookDetails(bookId);
    //    var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files");
    //    if (System.IO.File.Exists(filePath))
    //    {
    //        var content = System.IO.File.ReadAllBytes(filePath);
    //        return File(content, "aplication/pdf", filename);
    //    }
    //    else
    //    {
    //        return NotFound($"The file '{filename}' does not exist.");
    //    }

    //}
}
