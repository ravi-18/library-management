using AuthApi.Dtos.Auth;
using AuthApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.UserRegisterAsync(registerDto);
            return Ok(new { Message = "User registered successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authResponse = _userService.UserLoginAsync(loginDto);
            return Ok(authResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("AddRoles")]
    public async Task<IActionResult> AddRoles([FromBody] AddRoleDto addRoleDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Logic to add roles to the user
            // This is a placeholder implementation
            return Ok(new { Message = "Roles added successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}