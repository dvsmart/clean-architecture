using System.Collections.Generic;

namespace Q.Web.Helpers
{
    public class PagedResultModel<D>: PagingRequestBase where D: class
    {
        public List<D> Data { get; set; }

        public PagedResultModel()
        {
            Data = new List<D>();
        }
    }
}