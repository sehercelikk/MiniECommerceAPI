using MiniECommerce.Domain.Abstract;

namespace MiniECommerce.Domain.Concrete;

public class User : BaseEntity, IEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public List<Order> Orders { get; set; }
}
