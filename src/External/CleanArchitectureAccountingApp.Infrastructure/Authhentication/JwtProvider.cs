using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CleanArchitectureAccountingApp.Application.Abstractions;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitectureAccountingApp.Infrastructure.Authhentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<AppUser> _userManager;

    public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<string> CreateTokenAsync(AppUser user, List<string> roles)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}"),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Authentication, user.Id.ToString()),
            new(ClaimTypes.Role, string.Join(",", roles))
        };
        DateTime expires = DateTime.Now.AddDays(1);
        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha512)
        );

        string token = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);

        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddDays(1);
        await _userManager.UpdateAsync(user);
        return token;
    }
}