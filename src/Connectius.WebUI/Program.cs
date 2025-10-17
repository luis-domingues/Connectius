using Connectius.Application.Handlers;
using Connectius.Application.Interfaces;
using Connectius.Domain.Interfaces;
using Connectius.Infrastructure.Data;
using Connectius.Infrastructure.Repositories;
using Connectius.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDbContext>(options => options
    .UseSqlite(builder.Configuration
        .GetConnectionString("UserConnection")));

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasherAdapter>();

builder.Services.AddControllers();
builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
