namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.AppUserFeatures.Login;

public sealed class LoginResponse
{
    public string Token { get; set; }
    public string? Email { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}