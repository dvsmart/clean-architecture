using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomFieldValue : BaseEntity
    {
        public int CustomFieldId { get; set; }

        public int CustomEntityRecordId { get; set; }

        public string Value { get; set; }

        public virtual CustomEntityInstance CustomEntityRecord { get; set; }

    }
}
