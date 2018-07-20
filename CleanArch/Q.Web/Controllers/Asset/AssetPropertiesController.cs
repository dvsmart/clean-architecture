﻿using System.Collections.Generic;
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

        // GET: api/AssetProperties/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/AssetProperties
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/AssetProperties/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
