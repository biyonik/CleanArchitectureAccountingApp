using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Abstractions;

public interface IJwtProvider
{
    string CreateToken(AppUser user, List<string> roles);
}