using System.Collections.Generic;

namespace Q.Domain.CustomEntity
{
    public class CustomFieldType : IBaseEntity
    {
        public string Type { get; set; }

        public string Caption { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
    }
}
