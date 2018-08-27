using System.Collections.Generic;

namespace Q.Domain.CustomEntity
{
    public class CustomFieldType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
    }
}
