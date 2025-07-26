using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop2.Web.Controllers;

public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    private readonly IOrderService _orderService;
    public CommentController(ICommentService commentService, IOrderService orderService)
    {
        _commentService = commentService;
        _orderService = orderService;
    }

    [Route("api/comments/{bookId}")]
    [HttpGet]
    public async Task<IActionResult> GetAllByBookAsync(int bookId)
    {
        var comments = await _commentService.GetAllCommentsByBookAsync(bookId);
        return PartialView("_BookComments", comments);
    }

    [HttpPost]
    [Route("api/comments")]
   // [Authorize]
    public async Task<IActionResult> AddCommentAsync(string note, int bookId)
    {
        var userId = User.GetUserId();
        if (string.IsNullOrEmpty(note))
        {
            return BadRequest("Can not leave an Empty Comment!");
        }
        if (!await _orderService.IsBoughtByThisUser(userId, bookId))
        {
            return BadRequest("You must purchase the book before you can leave a comment.");
        }
  
        var output = await _commentService.AddAsync(new CommentCreation
        {
            Note = note,
            BookId = bookId,
            UserId = userId,
            TimeCreation = DateTime.Now,
            UserName = User.GetUserName()
        });

        return PartialView("_LastComment", output);

    }
}
