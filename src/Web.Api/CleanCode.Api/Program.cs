using CleanCode.Domain.Entities.Authentication.Roles;
using CleanCode.Domain.Entities.Authentication.Users;
using CleanCode.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<WriteDbContext>(options =>
options.UseNpgsql(builder.Configuration
.GetConnectionString("WriteDbConnection"), b =>
b.MigrationsAssembly(typeof(WriteDbContext).Assembly.FullName)));

builder.Services.AddIdentity<ApplicationUser, Role>().AddEntityFrameworkStores<WriteDbContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
