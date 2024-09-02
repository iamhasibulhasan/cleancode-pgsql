using CleanCode.Application.RepositoryInterfaces.Common;
using CleanCode.Domain.Entities.Authentication.Roles;

namespace CleanCode.Application.RepositoryInterfaces.Authentication.Users
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
    }
}
