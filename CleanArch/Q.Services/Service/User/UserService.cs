using Q.Domain;
using Q.Infrastructure;
using Q.Services.Interfaces.User;
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

        public async Task<PagedResult<Domain.User.User>> GetAll(int page, int? pageSize)
        {
            return await _userRepository.GetAll(page, pageSize);
        }
    }
}
