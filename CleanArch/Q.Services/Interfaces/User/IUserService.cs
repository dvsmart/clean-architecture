using Q.Domain;

namespace Q.Services.Interfaces.User
{
    public interface IUserService
    {
        PagedResult<Domain.User.User> GetAll(int page, int? pageSize);
    }
}
