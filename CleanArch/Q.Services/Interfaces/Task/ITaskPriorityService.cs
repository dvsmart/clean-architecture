using System.Collections.Generic;
using System.Threading.Tasks;
using Q.Domain.Task;
using Q.Services.Interfaces.Generic;

namespace Q.Services.Interfaces.Task
{
    public interface ITaskPriorityService
    {
        Task<IEnumerable<TaskPriority>> List();
    }
}