using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q.Domain.Asset;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Asset.Properties;
using Q.Web.Filters;
using Q.Web.Helpers;
using Q.Web.Models;
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

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _assetPropertyService.GetById(id);
            var model = _outputConverter.Map<CreateAssetPropertyRequest>(res);
            return Ok(model);
        }

        [HttpPost]
        [Route("deleteAll")]
        public async Task<HttpResponseMessage> DeleteAll([FromBody]DeleteModel deleteModel)
        {
            if (deleteModel == null && !deleteModel.Ids.Any())
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            await _assetPropertyService.DeleteAll(deleteModel.Ids);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [HttpDelete("{recordId}", Name = "delete")]
        public async Task<IActionResult> Delete(int recordId)
        {
            await _assetPropertyService.Delete(recordId);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateAssetPropertyRequest createNewPropertyRequest)
        {
            if (createNewPropertyRequest == null)
                return new BadRequestResult();
            var propertyDto = _outputConverter.Map<AssetProperty>(createNewPropertyRequest);
            var response = await _assetPropertyService.Insert(propertyDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]CreateAssetPropertyRequest createNewPropertyRequest)
        {
            if (createNewPropertyRequest == null)
                return new BadRequestResult();
            var propertyDto = _outputConverter.Map<AssetProperty>(createNewPropertyRequest);
            var response = await _assetPropertyService.Update(propertyDto);
            return Ok(response);
        }
    }
}
