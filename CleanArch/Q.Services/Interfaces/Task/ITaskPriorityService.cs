using System.Collections.Generic;
using System.Threading.Tasks;
using Q.Domain.Task;

namespace Q.Services.Interfaces.Task
{
    public interface ITaskPriorityService
    {
        Task<IEnumerable<TaskPriority>> List();
    }
}