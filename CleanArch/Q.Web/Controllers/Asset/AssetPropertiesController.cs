using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Asset.Properties;
using Q.Web.Helpers;
using Q.Web.Models.Asset;

namespace Q.Web.Controllers.Asset
{
    [Produces("application/json")]
    [Route("api/AssetProperties")]
    public class AssetPropertiesController : Controller
    {
        private readonly IAssetPropertyService _assetPropertyService;
        private readonly IOutputConverter _outputConverter;

        public AssetPropertiesController(IAssetPropertyService assetPropertyService, IOutputConverter outputConverter)
        {
            _assetPropertyService = assetPropertyService;
            _outputConverter = outputConverter;
        }

        // GET: api/AssetProperties
        [HttpGet]
        public IActionResult Get(int page, int pageSize)
        {
            var data = _assetPropertyService.GetAll(page, pageSize);
            if (data != null && data.Result != null)
            {
                var properties = data.Result.Results != null ? _outputConverter.Map<List<AssetProperties>>(data.Result.Results) : null;
                var result = properties.GetPagedResult(data.Result.PageSize, data.Result.CurrentPage, data.Result.RowCount);
                return new OkObjectResult(result);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{recordId}", Name = "delete")]
        public async Task<IActionResult> Delete(int recordId)
        {
            await _assetPropertyService.Delete(recordId);
            return Ok();
        }

        [HttpDelete("{ids}", Name = "DeleteAll")]
        public async Task<IActionResult> DeleteAll(List<int> ids)
        {
            await _assetPropertyService.DeleteAll(ids);
            return Ok();
        }
    }
}
