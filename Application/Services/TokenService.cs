using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs.AuthenticationDto;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class TokenService  : ITokenService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    
    public async Task<AuthResponseDto> CreateTokenAsync(ApplicationUser user)
    {
        //All configs from appsettings.json
        var jwtSection = _configuration.GetSection("JwtSettings");
        var secret = jwtSection["Secret"];
        var issuer = jwtSection["Issuer"];
        var audience = jwtSection["Audience"];
        var expiresMinutes = int.Parse(jwtSection["ExpiresMinutes"] ?? "60");
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id), // 1 change
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role", "Student")
        };
        
        var roles = await _userManager.GetRolesAsync(user);

        /* foreach (var role in roles)
        {
            Console.WriteLine(role);
            claims.Add(new Claim(ClaimTypes.Role, role));
        }*/
        
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!));
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            

        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new AuthResponseDto
        {
            Token = tokenString,
            ExpiresAt = token.ValidTo,
            Roles = roles.ToArray()
        };

          
            
    }
}