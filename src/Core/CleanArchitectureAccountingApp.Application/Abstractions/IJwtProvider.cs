using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Abstractions;

public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user, List<string> roles);
}