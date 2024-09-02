using CleanCode.Domain.Entities.Authentication.Roles;
using CleanCode.Infrastructure.Persistence;
using CleanCode.Infrastructure.RepositoryImplementations.Common;

namespace CleanCode.Infrastructure.RepositoryImplementations.Authentication.Users
{
    public sealed class RoleRepository : GenericRepository<Role>
    {
        private readonly WriteDbContext _writeDbContext;

        public RoleRepository(WriteDbContext writeDbContext) : base(writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
    }
}
