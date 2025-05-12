using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BookShop2.Web.Controllers;

[Route("[controller]/[action]")]
public class FilesController : Controller
{
    private readonly IFileService _fileService;
    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet]
    public async Task<IActionResult> DownloadAsync(string filename)
    {
        var file = await _fileService.GetFileByNameAsync(filename);
        return file != null ? File(file.Value.content, "application/pdf", file.Value.fileName)
            : NotFound($"The file '{filename}' does not exist.");
   
    }

    [HttpGet]
    [Route("api/book/download/{bookId}")]
    [Authorize]
    public async Task<IActionResult> DownloadAsync(int bookId)
    {
        var userclaim = User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = userclaim!.Value;
        var file = await _fileService.GetUserBookFileAsync(userId,bookId);
        return file != null ? File(file.Value.content, "application/pdf", file.Value.fileName)
            : NotFound("You are not allowed to download this file or it doesn't exist.");
    }
}
