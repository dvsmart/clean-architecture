using System.Collections.Generic;
using System.Linq;
using Q.Domain.Menu;
using Q.Web.Models.Base;

namespace Q.Web.Models.Menu
{
    public class MenuModel : BaseModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }

        public bool HasChildren { get; set; }

        public string Classess { get; set; }

        public string Icon { get; set; }

        public bool IsVisible { get; set; }

        public int SortOrder { get; set; }

        public int MenuGroupId { get; set; }
        public int? ParentId { get; set; }

        public string ExternalUrl { get; set; }

        public bool? OpenInNewTab { get; set; }

        public List<MenuModel> Children { get; set; }

        
    }
}
