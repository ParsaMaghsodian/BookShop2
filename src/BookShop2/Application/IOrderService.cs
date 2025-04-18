using BookShop2.Application.DTO;

namespace BookShop2.Application;

public interface IOrderService
{
    public int Add(OrderCreateModel order);
    public void Confirm(int orderId);
    public OrderDetails GetOrder(int orderId);
}