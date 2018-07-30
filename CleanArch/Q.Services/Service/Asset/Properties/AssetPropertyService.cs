using Q.Domain;
using Q.Domain.Asset;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Helper;
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
            
            var assetSavedResponse = await _assetRepository.Insert(asset);
            if (assetSavedResponse)
            {
                entity.AssetId = asset.Id;
                var id = _assetPropertyRepository.LatestRecordId().Value;
                entity.DataId = DataIdGenerationService.GenerateDataId(id, "AR");
                var propertySavedResponse = await _assetPropertyRepository.Insert(entity);
                return new SaveResponseDto
                {
                    SavedDataId = entity.DataId,
                    SavedEntityId = entity.AssetId,
                    SaveSuccessful = propertySavedResponse,
                };
            }
            return new SaveResponseDto
            {
                SaveSuccessful = false,
                ErrorMessage = "Failed adding new property."
            };
        }

        public async Task<SaveResponseDto> Update(AssetProperty entity)
        {
            if (entity.DataId == null)
            {
                var id = _assetPropertyRepository.LatestRecordId().Value;
                entity.DataId = DataIdGenerationService.GenerateDataId(id, "AR");
            }
            var response = await _assetPropertyRepository.Update(entity);
            return new SaveResponseDto
            {
                SavedDataId = entity.DataId,
                SavedEntityId = entity.AssetId,
                SaveSuccessful = response ? response : false,
                ErrorMessage = response == true ? string.Empty : "update failed"
            };
        }
    }
}
