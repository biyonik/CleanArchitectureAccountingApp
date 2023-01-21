using CleanArchitectureAccountingApp.Application.Abstractions;
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.AppUserFeatures.Login;


public sealed class Login
{
    public sealed record Command(string EmailOrUserName, string Password) : ICommand<Response>;
    
    public sealed record Response(
        string Token,
        string Email,
        Guid UserId,
        string FirstName,
        string LastName);
    
    public sealed class Handler: ICommandHandler<Command, Response>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;
    
        public Handler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.Users
                .Where(p => p.Email == request.EmailOrUserName || p.UserName == request.EmailOrUserName)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (user == null) throw new Exception("Kullanıcı bulunamadı!");
        
            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Parola yanlış!");

            List<string?> roles = new List<string?>();
            var token = await _jwtProvider.CreateTokenAsync(user, roles);
            Response response = new(
                token,
                user.Email,
                user.Id,
                user.FirstName,
                user.LastName
            );
            return response;
        }
    }
}
