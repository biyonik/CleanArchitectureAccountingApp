using CleanArchitectureAccountingApp.Application.Abstractions;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.AppUserFeatures.Login;

public sealed class LoginHandler: IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<AppUser?> _userManager;
    
    public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser?> userManager)
    {
        _jwtProvider = jwtProvider;
        _userManager = userManager;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        AppUser? user = await _userManager.Users
            .Where(p => p.Email == request.EmailOrUserName || p.UserName == request.EmailOrUserName)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (user == null) throw new Exception("Kullanıcı bulunamadı!");
        
        var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!checkUser) throw new Exception("Parola yanlış!");

        LoginResponse response = new()
        {
            Email = user.Email,
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = await _jwtProvider.CreateTokenAsync(user, null)
        };
        return response;
    }
}