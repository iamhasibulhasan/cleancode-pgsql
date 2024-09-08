using CleanCode.Application.Common.Utilities;
using CleanCode.Application.Features.Authentication.Users;
using CleanCode.Application.RepositoryInterfaces.Authentication.Users;
using CleanCode.Application.ServiceIntefaces.Authentication.Users;
using CleanCode.Domain.Entities.Authentication.Users;

namespace CleanCode.Infrastructure.ServiceImplementations.Authentication.Users
{
    public sealed class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;

        public ApplicationUserService(IApplicationUsersRepository applicationUsersRepository)
        {
            _applicationUsersRepository = applicationUsersRepository;
        }

        public async Task<Result> Post(ApplicationUserDto model, CancellationToken cancellationToken = default, bool saveChanges = true)
        {
            var user = new ApplicationUser();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Location = model.Location;
            user.PhoneNumber = model.PhoneNumber;
            user.CreatedAt = DateTime.UtcNow;
            user.CreatedBy = 1;

            await _applicationUsersRepository.InsertAsync(user, saveChanges, cancellationToken);
            return Utility.GetSuccessMsg("Save successful.");
        }
    }
}
