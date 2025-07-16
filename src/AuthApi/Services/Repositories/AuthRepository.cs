using AuthApi.Data;
using AuthApi.Dtos.Auth;
using AuthApi.Interfaces.Repositories;
using AuthApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthApi.Services.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<ApplicationUser> InsertAsync(RegisterDto registerDto)
    {
        var user = new ApplicationUser
        {
            UserName = registerDto.Email,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        var roleResult = await _userManager.AddToRoleAsync(user, registerDto?.Role ?? "User");
        if (!roleResult.Succeeded)
        {
            throw new Exception(string.Join(", ", roleResult.Errors.Select(e => e.Description)));
        }

        return user;
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}