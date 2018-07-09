using Q.Domain;
using Q.Services.Interfaces.Generic;

namespace Q.Services.Interfaces.Assessment
{
    public interface IAssessmentService : IGenericService
    {
        PagedResult<Domain.Assessment.Assessment> GetAll(int page, int? pageSize);
    }
}
