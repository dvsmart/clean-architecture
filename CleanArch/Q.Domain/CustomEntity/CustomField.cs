using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomField : BaseEntity
    {
        public string FieldName { get; set; }

        public int FieldTypeId { get; set; }

        public int CustomTabId { get; set; }

        public bool? IsMandatory { get; set; }

        public string ToolTip { get; set; }

        public string DefaultValue { get; set; }

        public short? SortOrder { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool? IsVisible { get; set; } = true;

        public virtual CustomFieldType CustomFieldType { get; set; }

        public virtual CustomTab CustomTab { get; set; }

        public virtual ICollection<CustomFieldValue> CustomFieldValues { get; set; }
    }
}
