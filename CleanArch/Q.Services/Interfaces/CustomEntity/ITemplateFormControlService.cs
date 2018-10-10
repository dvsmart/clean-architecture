using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ITemplateFormControlService
    {
        Task<IEnumerable<CustomField>> GetAll();

        Task<SaveResponseDto> Add(CustomField customField);

        Task<SaveResponseDto> UpdateAsync(CustomField customField);

        Task<SaveResponseDto> DeleteAsync(int id);

        Task<IEnumerable<CustomField>> GetFieldsByTabId(int id);
    }
}
