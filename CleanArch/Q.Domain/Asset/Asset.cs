using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.Asset
{
    public class Asset : BaseEntity
    {
        public int? PortfolioId { get; set; }

        public int? SubPortfolioId { get; set; }

        public int? ManagingAgentId { get; set; }

        public int? ManagingAgentPortfolioId { get; set; }
        
        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public int AssetTypeId { get; set; }

        public virtual AssetType AssetType { get; set; }

        public virtual ICollection<AssetProperty> AssetProperties { get; set; }
    }
}
