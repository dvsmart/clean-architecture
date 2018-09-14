using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Q.Domain.Asset;
using Q.Infrastructure.Mappings;
using Q.Services.Interfaces.Asset.Properties;
using Q.Web.Helpers;
using Q.Web.Models;
using Q.Web.Models.Asset;

namespace Q.Web.Controllers.Asset
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class AssetPropertiesController : Controller
    {
        private readonly IAssetPropertyService _assetPropertyService;
        private readonly IOutputConverter _outputConverter;

        private readonly Presenter _presenter;

        public AssetPropertiesController(IAssetPropertyService assetPropertyService, IOutputConverter outputConverter,Presenter presenter )
        {
            _assetPropertyService = assetPropertyService;
            _outputConverter = outputConverter;
            _presenter = presenter;
        }

        // GET: api/AssetProperties
        [HttpGet]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            var data = await _assetPropertyService.GetAll(page, pageSize);
            
            _presenter.Populate(data, _outputConverter);
            return _presenter.ViewModel;
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


        [HttpDelete]
        public async Task<IActionResult> Delete(int recordId)
        {
            await _assetPropertyService.Delete(recordId);
            return Ok();
        }

        [HttpPost]
        //[Route("create")]
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
