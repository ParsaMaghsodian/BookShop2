using BookShop2.Application.DTO;
using BookShop2.Infrastructure.DataModels.Enums;

namespace BookShop2.Application.Interfaces;

public interface IOrderService
{
    public int Add(OrderCreateModel order);
    public void Confirm(int orderId);
    public OrderDetails GetOrder(int orderId);
    public Task<IList<TopSellingBookItem>> GetTopSellingBooksAsync(int count = 3);
    Task<bool> IsBoughtByThisUser(string userId, int bookId);
    Task<IEnumerable<OrderItems>> GetAllOrdersAsync();
    Task<IEnumerable<UserOrderItem>> GetAllOrdersByUserAsync(string userId);
    Task AddRatingAsync(int orderId, RatingScore score);
}