using Q.Domain;
using Q.Infrastructure.Mappings;
using Q.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Q.Web.Helpers
{
    public static class ExtensionHelper
    {
        public static PagedResultModel<T> GetPagedResult<T>(this List<T> result, int pageSize, int currentPage, int? count) where T : class
        {
            return new PagedResultModel<T>()
            {
                PageSize = pageSize,
                CurrentPage = currentPage,
                TotalCount = count.Value,
                Data = result
            };
        }
    }
}