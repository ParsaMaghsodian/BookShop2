using BookShop2.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Interfaces;

public interface ICommentService
{
    public Task<CommentOutput> AddAsync(CommentCreation comment);
    public Task<IEnumerable<CommentOutput>> GetAllCommentsByBookAsync(int bookId);
}
