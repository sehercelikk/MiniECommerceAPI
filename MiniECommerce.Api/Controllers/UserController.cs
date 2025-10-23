using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Application.Services.UserServices;
using MiniECommerce.Dtos.UserDtos;
using System.Threading.Tasks;

namespace MiniECommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IAuthService _userService;

    public UserController(IAuthService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(RegisterDto model)
    {
        await _userService.RegisterAsync(model);
        return Ok();
    }
}
