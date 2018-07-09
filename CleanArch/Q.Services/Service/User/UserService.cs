using Q.Domain;
using Q.Domain.User;
using Q.Infrastructure;
using Q.Services.Interfaces.User;
using System;

namespace Q.Services.Service.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Domain.User.User> _userRepository;

        public UserService(IRepository<Domain.User.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(Domain.User.User user)
        {
            _userRepository.Insert(user);
        }

        public PagedResult<Domain.User.User> GetAll(int page, int? pageSize)
        {
            return _userRepository.GetAll(page, pageSize);
        }
    }
}
