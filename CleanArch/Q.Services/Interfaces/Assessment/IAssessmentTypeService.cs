using Q.Domain.Assessment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Assessment
{
    public interface IAssessmentTypeService
    {
        Task<IEnumerable<AssessmentType>> GetAssessmentTypes();

    }
}
