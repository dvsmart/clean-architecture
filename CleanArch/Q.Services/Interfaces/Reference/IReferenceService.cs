using Q.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Reference
{
    public interface IReferenceService
    {
        Task<IEnumerable<RecurrenceType>> GetFrequencies();
    }
}
