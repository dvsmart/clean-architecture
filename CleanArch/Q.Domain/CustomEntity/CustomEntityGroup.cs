using System.Collections.Generic;

namespace Q.Domain.CustomEntity
{
    public class CustomEntityGroup : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<CustomEntity> CustomEntities { get; set; }
    }
}
