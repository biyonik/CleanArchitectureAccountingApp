using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchitectureAccountingApp.Application.Abstractions;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitectureAccountingApp.Infrastructure.Authhentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;

    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string CreateToken(AppUser user, List<string> roles)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}"),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Authentication, user.Id.ToString()),
            new(ClaimTypes.Role, string.Join(",", roles))
        };
        
        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha512)
        );

        string token = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);
        return token;
    }
}