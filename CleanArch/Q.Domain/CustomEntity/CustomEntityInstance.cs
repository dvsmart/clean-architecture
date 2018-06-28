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

        public bool IsArchived { get; set; }

        public int Status { get; set; }

        public virtual CustomEntity CustomEntity { get; set; }

        public virtual ICollection<CustomFieldValue> CustomFieldValues { get; set; }

    }
}
