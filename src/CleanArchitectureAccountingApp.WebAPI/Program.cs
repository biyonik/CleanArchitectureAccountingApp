using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using CleanArchitectureAccountingApp.WebAPI.Configurations;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser()
        {
            Email = "ahmetaltun60@gmail.com",
            UserName = "ahmetaltun",
            Id = Guid.NewGuid(),
            FirstName = "Ahmet",
            LastName = "Altun"
        }, "123456/*").Wait();
    }
}

app.Run();