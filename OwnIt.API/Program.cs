using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using OwnIt.Injection;
using OwnIt.Persistence;

var builder = WebApplication.CreateBuilder(args);

string defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OwnItContext>(options =>
{
    options.UseInMemoryDatabase(defaultConnection);
    options.LogTo(Console.WriteLine, LogLevel.Warning);
    options.EnableSensitiveDataLogging(false);
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.RegisterServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseForwardedHeaders();
app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.Run();
