using CleanCode.Application.RepositoryInterfaces.Authentication.Users;
using CleanCode.Application.ServiceIntefaces.Authentication.Users;

namespace CleanCode.Infrastructure.ServiceImplementations.Authentication.Users
{
    public sealed class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
    }
}
