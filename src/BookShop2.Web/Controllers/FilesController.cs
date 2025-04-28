using BookShop2.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BookShop2.Web.Controllers;

[Route("[controller]/[action]")]
public class FilesController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IBookService _bookService;
    private readonly IOrderService _orderService;
    public FilesController(IWebHostEnvironment webHostEnvironment, IBookService bookService, IOrderService orderService)
    {
        _webHostEnvironment = webHostEnvironment;
        _bookService = bookService;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> DownloadAsync(string filename)
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", filename);
        if (System.IO.File.Exists(filePath))
        {
            var content = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(content, "aplication/pdf", filename);
        }
        else
        {
            return NotFound($"The file '{filename}' does not exist.");
        }

    }

    [HttpGet]
    [Route("api/book/download/{bookId}")]
    public async Task<IActionResult> DownloadAsync(int bookId)
    {
        var userclaim = User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = userclaim!.Value;
        bool isAllowed = await _orderService.IsBoughtByThisUser(userId, bookId);
        var book = _bookService.GetBookDetails(bookId);
        if (isAllowed && book.FileName != null)
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", book.FileName);
            if (System.IO.File.Exists(filePath))
            {
                var content = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(content, "aplication/pdf", book.FileName);
            }
            else
            {
                return NotFound($"The file '{book.FileName}' does not exist.");
            }
        }
        else
        {
            return NotFound($"You did not buy '{book.FileName}'");
        }
    }
}
