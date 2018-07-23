using Q.Domain;
using Q.Domain.Response;
using Q.Domain.User;
using Q.Infrastructure;
using Q.Services.Interfaces.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Domain.User.User> _userRepository;

        public UserService(IRepository<Domain.User.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async void Add(Domain.User.User user)
        {
            await _userRepository.Insert(user);
        }

        public System.Threading.Tasks.Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAll(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedResult<Domain.User.User>> GetAll(int page, int? pageSize)
        {
            return await _userRepository.GetAll(page, pageSize);
        }

        public Task<SaveResponseDto> Insert(Domain.User.User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
