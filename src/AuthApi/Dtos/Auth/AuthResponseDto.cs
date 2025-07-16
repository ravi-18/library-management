namespace AuthApi.Dtos.Auth;

public class AuthResponseDto
{
    public string AccessToken { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public string Email { get; set; } = default!;
}