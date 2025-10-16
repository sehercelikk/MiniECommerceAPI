using MiniECommerce.Domain.Abstract;

namespace MiniECommerce.Domain.Concrete;

public class Order : BaseEntity, IEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public decimal TotalPrice { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
