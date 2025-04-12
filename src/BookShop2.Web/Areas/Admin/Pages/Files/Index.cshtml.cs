using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Files;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public IndexModel(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public IList<FileInfo> FilesList { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    public void OnGet()
    {
        var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files");
        var files = Directory.GetFiles(path).ToList();
        FilesList = new List<FileInfo>();
        foreach (var file in files)
        {
            FilesList.Add(new FileInfo(file));
        }
    }
    public IActionResult OnPost(string filename)
    {
        var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", filename);
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
            StatusMessage = $"The file '{filename}' has been deleted successfully.";
        }
        else 
        {
            StatusMessage = $"Warning: The file '{filename}' does not exist.";
        }
        return RedirectToPage();
    }
}
