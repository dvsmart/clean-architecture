using Q.Services.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Event
{
    public interface IEventService : IGenericService<Domain.Event.Event>
    {

    }
}
