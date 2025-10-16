using MiniECommerce.Domain.Abstract;

namespace MiniECommerce.Domain.Concrete;

public class Category : BaseEntity, IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; }
}
