using Q.Domain;
using Q.Services.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Services.Interfaces.Asset.Properties
{
    public interface IAssetPropertyService : IGenericService
    {
        PagedResult<Domain.Asset.AssetProperty> GetAll(int page, int? pageSize);
    }
}
