using MiniECommerce.Domain.Abstract;

namespace MiniECommerce.Domain.Concrete;

public class OrderItem :BaseEntity,IEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
