using Q.Services.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Task
{
    public interface ITaskStatusService
    {
        Task<IEnumerable<Domain.Task.TaskStatus>> List();
    }
}
