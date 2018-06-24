using Q.Infrastructure.Mappings;
using System.Collections.Generic;

namespace Q.Web.Helpers
{
    public class PagedResultModel<T>: PagingRequestBase
    {
        public IList<T> Data { get; set; }

        public PagedResultModel()
        {
            Data = new List<T>();
        }
    }
}