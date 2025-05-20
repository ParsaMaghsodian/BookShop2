using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookShop2.Web.Areas.Admin.Pages.Files;

public class UploadModel : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IFileService _fileService;
    public UploadModel(IWebHostEnvironment webHostEnvironment, IFileService fileService)
    {
        _webHostEnvironment = webHostEnvironment;
        _fileService = fileService;
    }
    [BindProperty]
    [Required(ErrorMessage = "Please Upload the File")]
    public IFormFile UploadedFile { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        bool result = await _fileService.CreateFileAsync(UploadedFile);
        if (!result)
        {
            ModelState.AddModelError("UploadedFile", "Erorr: A file with the same name already exists.");
            return Page();
        }
        StatusMessage = "The File has been Uploaded Successfully!";
        return RedirectToPage("./Index");
    }
    public void OnGet()
    {

    }
}
