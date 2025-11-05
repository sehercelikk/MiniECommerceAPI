using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniECommerce.Domain.Concrete;
using MiniECommerce.Dtos.UserDtos;
using MiniECommerce.Infrastructure.Repositories.UserRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

    public async Task<string> LoginAsync(LoginDto model)
    {
        var user = await _userRepository.GetByEmailAsync(model.Email);
        if (user==null)
        {
            throw new Exception("Kullanıcı Bulunamadı");
        }
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
        if (!isPasswordValid)
        {
            throw new Exception("Şifre Hatalı!");
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role ?? "User")
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
