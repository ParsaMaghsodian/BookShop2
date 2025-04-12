using Microsoft.AspNetCore.Mvc;

namespace BookShop2.Web.Controllers;

[Route("[controller]/[action]")]
public class FilesController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FilesController(IWebHostEnvironment webHostEnvironment)
    {
            _webHostEnvironment = webHostEnvironment;
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
}
