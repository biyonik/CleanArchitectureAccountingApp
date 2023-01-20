using CleanArchitectureAccountingApp.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
new PersistenceServiceInstaller().Install(builder.Services, builder.Configuration);
new PersistenceDIServiceInstaller().Install(builder.Services, builder.Configuration);
new ThirdPartyServiceInstaller().Install(builder.Services, builder.Configuration);
new GeneralServiceInstaller().Install(builder.Services, builder.Configuration);
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
app.UseAuthorization();

app.MapControllers();

app.Run();