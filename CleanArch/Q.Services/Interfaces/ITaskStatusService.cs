using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces
{
    public interface ITaskStatusService
    {
        Task<IEnumerable<Domain.Task.TaskStatus>> List();
    }
}
