using Microsoft.Extensions.Configuration;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Dtos.UserDtos;
using MiniECommerce.Infrastructure.Repositories.UserRepository;

namespace MiniECommerce.Application.Services.UserServices;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _config;

    public AuthService(IUserRepository userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _config = config;
    }

    public async Task<string> RegisterAsync(RegisterDto dto)
    {
        var emailChack= await _userRepository.GetByEmailAsync(dto.Email);
        if(emailChack!=null)
        {
            throw new Exception("Email zaten kayıtlı.");
        }
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        var user = new User
        {
            Email = dto.Email,
            PasswordHash = passwordHash,
            CreateDate = DateTime.UtcNow,
            IsActive = true,
            Role = "Customer",
            UserName = dto.UserName,
        };
        await _userRepository.AddAsync(user);
        return "Kayıt başarılı.";
    }
}
