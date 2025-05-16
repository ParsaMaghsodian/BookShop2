using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Files;

public class IndexModel : PageModel
{
    private readonly IFileService _fileService;
    public IndexModel(IFileService fileService)
    {
        _fileService = fileService;
    }
    public IEnumerable<FileInfo> FilesList { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    public void OnGet()
    {
        FilesList = _fileService.GetAllFiles();
    }
    public IActionResult OnPost(string filename)
    {
        if (_fileService.DeleteFile(filename))
        {
            StatusMessage = $"The file '{filename}' has been deleted successfully.";
        }
        else
        {
            StatusMessage = $"Warning: The file '{filename}' does not exist.";
        }
        return RedirectToPage();
    }
}
