using AuthApi.Dtos.Auth;
using AuthApi.Models;

namespace AuthApi.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<ApplicationUser> InsertAsync(RegisterDto registerDto);
    Task<ApplicationUser?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user);
}