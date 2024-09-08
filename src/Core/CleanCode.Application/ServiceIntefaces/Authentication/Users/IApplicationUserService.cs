using CleanCode.Application.Common.Utilities;
using CleanCode.Application.Features.Authentication.Users;

namespace CleanCode.Application.ServiceIntefaces.Authentication.Users
{
    public interface IApplicationUserService
    {
        Task<Result> Post(ApplicationUserDto model, CancellationToken cancellationToken = default, bool saveChanges = true);
    }
}
