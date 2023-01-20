using CleanArchitectureAccountingApp.Infrastructure.Authhentication;
using Microsoft.Extensions.Options;

namespace CleanArchitectureAccountingApp.WebAPI.OptionsSetup;

public sealed class JwtOptionsSetup: IConfigureOptions<JwtOptions>
{
    private const string JWT = nameof(JWT);
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(JWT).Bind(options);
    }
}