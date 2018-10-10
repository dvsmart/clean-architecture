using Q.Domain.CustomEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface IFormControlTypeService
    {
        Task<ICollection<CustomFieldType>> GetCustomFieldTypes();
    }
}
