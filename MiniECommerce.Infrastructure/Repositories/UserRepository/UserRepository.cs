using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Infrastructure.Repositories.GenericRepository;

namespace MiniECommerce.Infrastructure.Repositories.UserRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ETicaretContext _context;
    public UserRepository(ETicaretContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
    }
}
