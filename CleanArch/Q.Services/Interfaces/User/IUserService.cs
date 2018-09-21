﻿using Q.Domain;
using Q.Domain.Response;
using Q.Services.Interfaces.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.User
{
    public interface IUserService
    {
        void Add(Domain.User.User user);

        Domain.User.User Authenticate(string username, string password);

        Task<PagedResult<Domain.User.User>> GetAll(int page, int? pageSize);

        Task<SaveResponseDto> Update(Domain.User.User entity, string password = null);


        Domain.User.User CheckIfUserExists(int userId);

        Task<Domain.User.User> CreateAsync(Domain.User.User user, string password);
    }
}
