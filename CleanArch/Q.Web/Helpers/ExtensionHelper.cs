using Q.Domain;
using Q.Infrastructure.Mappings;
using System.Collections.Generic;

namespace Q.Web.Helpers
{
    public static class ExtensionHelper
    {
        public static PagedResultModel<T> GetPagedResult<T>(this List<T> result,int pageSize, int currentPage, int total) where T : class
        {
            var resultModel = new PagedResultModel<T>()
            {
                PageSize = pageSize,
                CurrentPage = currentPage,
                TotalCount = total,
                Data = result
            };
            return resultModel;
        }
    }
}