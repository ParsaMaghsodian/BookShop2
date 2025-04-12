using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookShop2.Web.Areas.Admin.Pages.Files;

public class UploadModel : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public UploadModel(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    [BindProperty]
    [Required(ErrorMessage = "Please Upload the File")]
    public IFormFile UploadedFile { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var rawFilename = Path.GetFileName(UploadedFile.FileName).Trim();
        var nameWithoutExtension = Path.GetFileNameWithoutExtension(rawFilename); // gets the file name only
        var extension = Path.GetExtension(rawFilename); // .pdf for instance
        // Replace 1 or more spaces with a single hyphen
        var cleanedName = Regex.Replace(nameWithoutExtension, @"\s+", "-");
        var finalFilename = cleanedName + extension;

        var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Areas", "Files", finalFilename);
        if (System.IO.File.Exists(path))
        {
            ModelState.AddModelError("UploadedFile", "Erorr: A file with the same name already exists.");
            return Page();
        }
        using var stream = System.IO.File.Create(path);
        stream.Position = 0;
        UploadedFile.CopyTo(stream);
        StatusMessage = "The File has been Uploaded Successfully!";
        return RedirectToPage("./Index");
    }
    public void OnGet()
    {

    }
}
