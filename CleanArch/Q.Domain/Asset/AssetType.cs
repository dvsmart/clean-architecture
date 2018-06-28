using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.Asset
{
    public class AssetType : BaseEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
