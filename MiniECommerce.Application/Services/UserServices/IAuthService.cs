using MiniECommerce.Dtos.UserDtos;

namespace MiniECommerce.Application.Services.UserServices;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto model);
}
