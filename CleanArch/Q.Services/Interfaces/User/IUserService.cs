using Q.Services.Interfaces.Generic;

namespace Q.Services.Interfaces.User
{
    public interface IUserService : IGenericService<Domain.User.User>
    {
        void Add(Domain.User.User user);
    }
}
