﻿using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using BookShop2.Infrastructure.DataModels.Enums;
using BookShop2.Migrations;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace BookShop2.Application.Services;
public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _db;

    public OrderService(ApplicationDbContext db)
    {
        _db = db;
    }

    public int Add(OrderCreateModel model)
    {
        var order = model.Adapt<OrderData>();
        order.TimeCreation = DateTime.Now;
        order.State = OrderState.New;
        _db.Orders.Add(order);
        _db.SaveChanges();
        return order.OrderId;
    }

    public void Confirm(int orderId)
    {
        var order = _db.Orders.Find(orderId);
        if (order.State == OrderState.New)
        {
            order.State = OrderState.Confirmed;
        }
        _db.SaveChanges();
    }

    public async Task<IEnumerable<OrderItems>> GetAllOrdersAsync()
    {
        return await _db.Orders.ProjectToType<OrderItems>().ToListAsync();
    }

    public async Task<IEnumerable<UserOrderItem>> GetAllOrdersByUserAsync(string userId)
    {
        return await _db.Orders.Where(o => o.UserId == userId && o.State == OrderState.Confirmed).ProjectToType<UserOrderItem>().ToListAsync();
    }

    public OrderDetails GetOrder(int orderId)
    {
        return _db.Orders
         .Select(o => new OrderDetails
         {
             Amount = o.Amount,
             BookName = o.Book.Name,
             UserName = o.User.UserName,
             CategoryName = o.Book.BookCategory.Name,
             OrderId = o.OrderId
         }).FirstOrDefault(o => o.OrderId == orderId);
    }
    public async Task<IList<TopSellingBookItem>> GetTopSellingBooksAsync(int count = 3)
    {
        var result = await _db.Orders
            .Where(o => o.State == OrderState.Confirmed)
            .GroupBy(o => new { o.BookId, o.Book.Name, o.Book.CoverImage })
            .Select(g => new TopSellingBookItem
            {
                BookId = g.Key.BookId,
                BookName = g.Key.Name,
                CoverImage = g.Key.CoverImage,
                NumberOfSales = g.Count()
            })
            .OrderByDescending(x => x.NumberOfSales)
            .Take(count)
            .ToListAsync();

        return result;
    }
    public async Task<bool> IsBoughtByThisUser(string userId, int bookId)
    {
        return await _db.Orders
            .AnyAsync(o => o.UserId == userId && o.BookId == bookId && o.State == OrderState.Confirmed);
    }
    public async Task AddRatingAsync(int orderId, RatingScore score)
    {
        var order = await _db.Orders.Include(b => b.Book).FirstAsync(o => o.OrderId == orderId);
        order.Rating = new RatingData
        {
            TimeCreation = DateTime.Now,
            BookId = order.BookId,
            OrderId = orderId,
            Score = score
        };
        var book = order.Book;
        var priorCounts = book.RatingCount;
        var priorAvg = book.AvgRating;
        var priorTotalScores = priorAvg * priorCounts;
        var newTotalScores = priorTotalScores + (int)score;
        book.RatingCount++;
        book.AvgRating = newTotalScores / book.RatingCount;
        await _db.SaveChangesAsync();
    }

}
