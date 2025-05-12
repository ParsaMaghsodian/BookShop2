using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Services;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _db;
    public CommentService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<CommentOutput> AddAsync(CommentCreation comment)
    {
        var entry = await _db.Comments.AddAsync(comment.Adapt<CommentData>());
        await _db.SaveChangesAsync();
        // Adapt the tracked entity
        return entry.Entity.Adapt<CommentOutput>();
    }

    public async Task<IEnumerable<CommentOutput>> GetAllCommentsByBookAsync(int bookId)
    {
        return await _db.Comments
            .Where(b => b.BookId == bookId)
            .OrderByDescending(t => t.TimeCreation) // Newest comments based on time
            .ProjectToType<CommentOutput>().ToListAsync();
    }
}
