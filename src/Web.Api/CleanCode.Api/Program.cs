using CleanCode.Application.RepositoryInterfaces.Common;
using CleanCode.Application.ServiceIntefaces.Authentication.Users;
using CleanCode.Domain.Entities.Authentication.Roles;
using CleanCode.Domain.Entities.Authentication.Users;
using CleanCode.Infrastructure.Persistence;
using CleanCode.Infrastructure.RepositoryImplementations.Common;
using CleanCode.Infrastructure.ServiceImplementations.Authentication.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<WriteDbContext>(options =>
//options.UseNpgsql(builder.Configuration
//.GetConnectionString("WriteDbConnection"), b =>
//b.MigrationsAssembly(typeof(WriteDbContext).Assembly.FullName)));

builder.Services.AddDbContext<WriteDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WriteDbConnection")));

builder.Services.AddIdentity<ApplicationUser, Role>().AddEntityFrameworkStores<WriteDbContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IRoleService, RoleService>();


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
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
