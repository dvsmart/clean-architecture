using Q.Domain;
using Q.Domain.Asset;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.Asset.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Services.Service.Asset.Properties
{
    public class AssetPropertyService : IAssetPropertyService
    {
        private readonly IRepository<AssetProperty> _assetPropertyRepository;
        private readonly IRepository<Domain.Asset.Asset> _assetRepository;

        public AssetPropertyService(IRepository<AssetProperty> assetPropertyRepository, IRepository<Domain.Asset.Asset> assetRepository)
        {
            _assetRepository = assetRepository;
            _assetPropertyRepository = assetPropertyRepository;
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var property = await _assetPropertyRepository.Get(id);
            await _assetPropertyRepository.Remove(property);
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

        public async Task<AssetProperty> GetById(int id)
        {
            return await _assetPropertyRepository.Get(id);
        }

        public async Task<SaveResponseDto> Insert(AssetProperty entity)
        {
            var asset = new Domain.Asset.Asset()
            {
                AssetTypeId = 3,
                AddedBy = 1,
                AddedDate = DateTime.Now,
                IsArchived = false,
                IsDeleted = false,
                ManagingAgentId = 1,
                ManagingAgentPortfolioId = 2,
                SubPortfolioId = null,
                PortfolioId = null,
            };
            await _assetRepository.Insert(asset);
            entity.AssetId = asset.Id;
            await _assetPropertyRepository.Insert(entity);
            return new SaveResponseDto
            {
                SavedDataId = entity.DataId,
                SavedEntityId = entity.AssetId,
                SaveSuccessful = true
            };
        }

        public async Task<SaveResponseDto> Update(int id, AssetProperty entity)
        {
            var property = _assetPropertyRepository.FindBy(x => x.Id == id && x.AssetId == entity.AssetId && !x.Asset.IsArchived && !x.Asset.IsDeleted)?.FirstOrDefault();
            if(property != null)
            {
                var response =  await _assetPropertyRepository.Update(entity);
                return new SaveResponseDto
                {
                    SavedDataId = entity.DataId,
                    SavedEntityId = entity.AssetId,
                    SaveSuccessful = response
                };
            }
            return new SaveResponseDto
            {
                SavedDataId = entity.DataId,
                SavedEntityId = entity.AssetId,
                SaveSuccessful = false,
                ErrorMessage = "Property does not exist"
            };

        }
    }
}
