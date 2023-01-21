using CleanArchitectureAccountingApp.Application.Abstractions;
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.AppUserFeatures.Login;

public sealed class Login
{
    public sealed record Command(string EmailOrUserName, string Password) : ICommand<Response>;

    public sealed class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(p => p.EmailOrUserName).NotEmpty().WithMessage("Email ya da kullanıcı adı boş bırakılamaz!");
            RuleFor(p => p.EmailOrUserName).NotNull().WithMessage("Email ya da kullanıcı adı boş bırakılamaz!");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Parola boş bırakılamaz!");
            RuleFor(p => p.Password).NotNull().WithMessage("Parola boş bırakılamaz!");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Parola en az 6 karakter uzunluğunda olabilir!");
            RuleFor(p => p.Password).MaximumLength(16).WithMessage("Parola en fazla 16 karakter uzunluğunda olabilir!");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Parola en az bir adet büyük harf içermelidir!");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Parola en az bir adet küçük harf içermelidir");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Parola en az bir adet rakam içermelidir");
            RuleFor(p => p.Password).Matches("[A-Za-z0-9]")
                .WithMessage("Parola en az bir adet özel karakter içermelidir");
        }
    }

    public sealed record Response(
        string Token,
        string Email,
        Guid UserId,
        string FirstName,
        string LastName);

    public sealed class Handler : ICommandHandler<Command, Response>
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