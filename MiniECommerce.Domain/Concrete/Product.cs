using MiniECommerce.Domain.Abstract;

namespace MiniECommerce.Domain.Concrete;

public class Product : BaseEntity, IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
