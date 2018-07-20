using Q.Domain;
using Q.Domain.Asset;
using Q.Infrastructure;
using Q.Services.Interfaces.Asset.Properties;
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

        public async Task<PagedResult<AssetProperty>> GetAll(int page, int? pageSize)
        {
            return await _assetPropertyRepository.GetAll(page, pageSize);
        }

    }
}
