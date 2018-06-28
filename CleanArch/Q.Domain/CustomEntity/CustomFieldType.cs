using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomFieldType : BaseEntity
    {
        public string Type { get; set; }
        public string Caption { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
    }
}
