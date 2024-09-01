using CleanCode.Application.RepositoryInterfaces;
using CleanCode.Domain.Entities.Authentication.Roles;
using CleanCode.Domain.Entities.Authentication.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Infrastructure.Persistence
{
    public sealed class WriteDbContext : IdentityDbContext<ApplicationUser, Role, int>, IWriteDbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }
        #region Authentication
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        #endregion Authentication

        #region Role
        public DbSet<Role> Roles { get; set; }
        #endregion Role
    }
}
