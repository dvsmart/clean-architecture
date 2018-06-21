using System.Collections.Generic;
using System.Threading.Tasks;
using Q.Domain.Task;

namespace Q.Services.Interfaces
{
    public interface ITaskPriorityService
    {
        Task<IEnumerable<TaskPriority>> List();
    }
}