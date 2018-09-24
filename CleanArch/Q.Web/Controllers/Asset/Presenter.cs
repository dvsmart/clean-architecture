﻿using Microsoft.AspNetCore.Mvc;
using Q.Domain;
using Q.Domain.Asset;
using Q.Infrastructure.Mappings;
using Q.Web.Helpers;
using Q.Web.Models.Asset;
using System.Collections.Generic;

namespace Q.Web.Controllers.Asset
{
    public sealed class Presenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(PagedResult<AssetProperty> output, IOutputConverter outputConverter)
        {
            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            var properties = outputConverter.Map<List<AssetProperties>>(output.Results);

            ViewModel = new ObjectResult(properties.GetPagedResult(output.PageSize, output.CurrentPage, output.RowCount));
        }

    }
}