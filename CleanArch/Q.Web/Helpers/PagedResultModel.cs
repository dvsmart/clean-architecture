using System.Collections.Generic;

namespace Q.Web.Helpers
{
    public class PagedResultModel<T>: PagingRequestBase where T: class
    {
        public List<T> Data { get; set; }

        public PagedResultModel()
        {
            Data = new List<T>();
        }
    }
}