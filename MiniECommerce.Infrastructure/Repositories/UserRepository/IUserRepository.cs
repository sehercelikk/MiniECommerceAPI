using MiniECommerce.Domain.Concrete;
using MiniECommerce.Infrastructure.Repositories.GenericRepository;

namespace MiniECommerce.Infrastructure.Repositories.UserRepository;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email);
}
