using System.Collections.Generic;
using Q.Web.Models.Base;

namespace Q.Web.Models.CustomEntity
{
    public class CustomEntityTemplateModel : BaseIdModel
    {
        public string TemplateName { get; set; }
    }

    public class CustomTemplateModel
    {
        public CustomTemplateModel()
        {
            Templates = new List<CustomEntityTemplateModel>();
        }
        public string GroupName { get; set; }

        public int GroupId { get; set; }

        public int Count { get { return Templates.Count; } private set { } }

        public List<CustomEntityTemplateModel> Templates { get; set; }
    }

    public class CreateCustomTemplateRequest : BaseIdModel
    {
        public string TemplateName { get; set; }

        public int GroupId { get; set; }
    }
}
