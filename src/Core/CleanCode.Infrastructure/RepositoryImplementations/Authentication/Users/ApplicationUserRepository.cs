using CleanCode.Domain.Entities.Authentication.Users;
using CleanCode.Infrastructure.Persistence;
using CleanCode.Infrastructure.RepositoryImplementations.Common;

namespace CleanCode.Infrastructure.RepositoryImplementations.Authentication.Users
{
    public sealed class ApplicationUserRepository : GenericRepository<ApplicationUser>
    {
        private readonly WriteDbContext _writeDbContext;

        public ApplicationUserRepository(WriteDbContext writeDbContext) : base(writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
    }
}
