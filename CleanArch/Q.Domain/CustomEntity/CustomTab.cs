﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomTab : BaseEntity
    {
        public string Name { get; set; }

        public bool IsVisible { get; set; } = true;

        public short? SortOrder { get; set; }

        public virtual CustomEntity CustomEntity { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
    }
}
