using System.Text;
using AuthApi.Dtos.Auth;
using AuthApi.Interfaces.Repositories;
using AuthApi.Interfaces.Services;
using AuthApi.Models;

namespace AuthApi.Services.Implementations;

public class UserService : IUserService
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _config;

    public UserService(IAuthRepository authRepository, IConfiguration config)
    {
        _authRepository = authRepository;
        _config = config;
    }

    public async Task<bool> UserRegisterAsync(RegisterDto registerDto)
    {
        // Validate the input data and create a new user
        if (registerDto == null || string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
        {
            throw new ArgumentException("Invalid registration data.");
        }

        var user = await _authRepository.InsertAsync(registerDto);

        if (user == null)
        {
            throw new Exception("User registration failed.");
        }

        return true;
    }

    public async Task<AuthResponseDto> UserLoginAsync(LoginDto loginDto)
    {
        // Implement login logic here
        // This is a placeholder implementation
        if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
        {
            throw new ArgumentException("Invalid login data.");
        }

        var user = await _authRepository.FindByEmailAsync(loginDto.Email);
        var isPasswordValid = user != null && await _authRepository.CheckPasswordAsync(user, loginDto.Password);

        if (user == null || !isPasswordValid)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var roles = await _authRepository.GetRolesAsync(user);

        // create token or any other authentication response
        var token = Helpers.GenerateToken.CreateJwtToken(user, roles, _config);

        // Simulate successful login response
        var authResponse = new AuthResponseDto
        {
            AccessToken = token, // Replace with actual token generation logic
            Email = loginDto.Email,
            UserId = user.Id,

        };

        return authResponse;
    }
}