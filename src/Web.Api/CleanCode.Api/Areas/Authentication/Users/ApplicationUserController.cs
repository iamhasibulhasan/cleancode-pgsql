using CleanCode.Application.Features.Authentication.Users;
using CleanCode.Application.ServiceIntefaces.Authentication.Users;
using Microsoft.AspNetCore.Mvc;

namespace CleanCode.Api.Areas.Authentication.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicationUserDto model, CancellationToken cancellationToken = default)
        {
            var data = await _applicationUserService.Post(model, cancellationToken);
            return Ok(data);
        }
    }
}
