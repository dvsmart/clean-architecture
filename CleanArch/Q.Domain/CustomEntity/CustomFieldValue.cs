using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomFieldValue : BaseEntity
    {
        public int CustomFieldId { get; set; }

        public int CustomEntityInstanceId { get; set; }

        public string Value { get; set; }

        public virtual CustomEntityInstance CustomEntityInstance { get; set; }

        public virtual CustomField CustomField { get; set; }

    }
}
