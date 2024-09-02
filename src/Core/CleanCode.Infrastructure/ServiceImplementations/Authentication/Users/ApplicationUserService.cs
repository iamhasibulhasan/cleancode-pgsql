using CleanCode.Application.RepositoryInterfaces.Authentication.Users;
using CleanCode.Application.ServiceIntefaces.Authentication.Users;

namespace CleanCode.Infrastructure.ServiceImplementations.Authentication.Users
{
    public sealed class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;

        public ApplicationUserService(IApplicationUsersRepository applicationUsersRepository)
        {
            _applicationUsersRepository = applicationUsersRepository;
        }
    }
}
