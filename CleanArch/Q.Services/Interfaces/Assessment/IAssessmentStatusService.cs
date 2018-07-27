using Q.Domain.Assessment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Assessment
{
    public interface IAssessmentStatusService
    {
        Task<IEnumerable<AssessmentStatus>> GetAssessmentStatuses();

    }
}
