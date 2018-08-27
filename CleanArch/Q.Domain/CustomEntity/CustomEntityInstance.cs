using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomEntityInstance : BaseEntity
    {
        public string InstanceId { get; set; }

        public int TemplateId { get; set; }

        public DateTime? DueDate { get; set; }

        public int Status { get; set; }

        public virtual CustomEntity CustomEntity { get; set; }

        public virtual ICollection<CustomFieldValue> CustomFieldValues { get; set; }

    }

    public class CustomEntityRecordDto
    {
        public CustomEntityRecordDto()
        {
            CustomTabs = new List<CustomTabDto>();
        }
        public int Id { get; set; }

        public string DataId { get; set; }

        public int CustomEntityId { get; set; }

        public List<CustomTabDto> CustomTabs { get; set; }
        
    }

    public class CustomTabDto
    {
        public CustomTabDto()
        {
            CustomFields = new List<CustomFieldDto>();
        }

        public int TabId { get; set; }

        public string Caption { get; set; }

        public short? SortOrder { get; set; }

        public bool IsVisible { get; set; }

        public List<CustomFieldDto> CustomFields { get; set; }
    }

    public class CustomFieldDto
    {
        public int FieldId { get; set; }

        public string Caption { get; set; }

        public short? SortOrder { get; set; }

        public bool IsVisible { get; set; }

        public string FieldType { get; set; }
    }
}
