using Q.Domain.Asset;
using Q.Domain.Response;
using Q.Services.Interfaces.Generic;
using System.Threading.Tasks;

namespace Q.Services.Interfaces.Asset.Properties
{
    public interface IAssetPropertyService : IGenericService<AssetProperty>
    {
        Task<SaveResponseDto> Update(int id, AssetProperty entity);

        Task<AssetProperty> GetById(int id);
    }
}
