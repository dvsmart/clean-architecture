using Q.Domain;
using Q.Domain.Asset;
using Q.Infrastructure;
using Q.Services.Interfaces.Asset.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Services.Service.Asset.Properties
{
    public class AssetPropertyService : IAssetPropertyService
    {
        private readonly IRepository<AssetProperty> _assetPropertyRepository;

        public AssetPropertyService(IRepository<AssetProperty> assetPropertyRepository)
        {
            _assetPropertyRepository = assetPropertyRepository;
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var property = await _assetPropertyRepository.Get(id);
            await _assetPropertyRepository.Delete(property);
        }

        public async System.Threading.Tasks.Task DeleteAll(List<int> ids)
        {
            var properties = _assetPropertyRepository.FindBy(x => ids.Contains(x.Id)).ToList();
            await _assetPropertyRepository.DeleteAll(properties);
        }

        public async Task<PagedResult<AssetProperty>> GetAll(int page, int? pageSize)
        {
            return await _assetPropertyRepository.GetAll(page, pageSize);
        }

    }
}
