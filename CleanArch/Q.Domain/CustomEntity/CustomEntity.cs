using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomEntity : BaseEntity
    {
        public string TemplateName { get; set; }

        public int EntityGroupId { get; set; }

        public virtual CustomEntityGroup CustomEntityGroup { get; set; }
    }
}
