using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomEntityGroup : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<CustomEntity> CustomEntities { get; set; }
    }
}
