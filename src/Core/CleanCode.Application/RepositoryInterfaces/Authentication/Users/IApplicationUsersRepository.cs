﻿using CleanCode.Application.RepositoryInterfaces.Common;
using CleanCode.Domain.Entities.Authentication.Users;

namespace CleanCode.Application.RepositoryInterfaces.Authentication.Users
{
    public interface IApplicationUsersRepository : IGenericRepository<ApplicationUser>
    {
    }
}
