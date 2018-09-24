using Q.Domain.Response;
using System.Collections.Generic;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ITemplateFormValueService
    {
        System.Threading.Tasks.Task<SaveResponseDto> Add(List<Domain.CustomEntity.CustomFieldValue> customFieldValues);
    }
}
