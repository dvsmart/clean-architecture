using Q.Domain.CustomEntity;
using Q.Domain.Response;
using System.Collections.Generic;

namespace Q.Services.Interfaces.CustomEntity
{
    public interface ITemplateCategoryService
    {
        System.Threading.Tasks.Task<IEnumerable<CustomEntityGroup>> GetGroups();

        System.Threading.Tasks.Task<SaveResponseDto> AddGroup(CustomEntityGroup customEntityGroup);

        System.Threading.Tasks.Task<SaveResponseDto> UpdateGroup(CustomEntityGroup customEntityGroup);

        System.Threading.Tasks.Task<SaveResponseDto> DeleteGroup(int id);

        System.Threading.Tasks.Task<CustomEntityGroup> GetGroupById(int id);
    }
}
