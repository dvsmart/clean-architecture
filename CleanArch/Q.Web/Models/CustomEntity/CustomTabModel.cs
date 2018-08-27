using System.Collections.Generic;

namespace Q.Web.Models.CustomEntity
{
    public class CustomTabModel : BaseIdModel
    {
        public string Caption { get; set; }

        public List<CustomFieldModel> CustomFields { get; set; }

        public int? CustomEntityId { get; set; }

        public string RecordId { get; set; }

        public short? SortOrder { get; set; }

        public bool IsVisible { get; set; }

    }

    public class CustomTabRequestModel
    {
        public int TabId { get; set; }

        public bool NotApplicable { get; set; }
    }

    public class CreateCustomTabRequest : BaseIdModel
    {
        public string Caption { get; set; }

        public int CustomEntityId { get; set; }
    }

    public class CustomInstanceModel
    {
        public int TabId { get; set; }

        public string TabCaption { get; set; }

        public short? SortOrder { get; set; }

        public bool IsVisible { get; set; }
    
        public List<CustomFieldModel> CustomFields { get; set; }
    }
}
