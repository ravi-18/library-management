using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi.Helpers;

public static class GenerateToken
{
    public static string CreateJwtToken(ApplicationUser user, IEnumerable<string> roles, IConfiguration config)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.Name, user?.UserName ?? string.Empty),
        new Claim(ClaimTypes.Role, string.Join(",", roles))
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            config["Jwt:Issuer"],
            config["Jwt:Issuer"],
            claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}