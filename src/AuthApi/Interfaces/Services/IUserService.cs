using AuthApi.Dtos.Auth;

namespace AuthApi.Interfaces.Services;

public interface IUserService
{
    Task<bool> UserRegisterAsync(RegisterDto registerDto);
    Task<AuthResponseDto> UserLoginAsync(LoginDto loginDto);
}