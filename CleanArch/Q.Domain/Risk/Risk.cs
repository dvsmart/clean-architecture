using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.Risk
{
    public class Risk : BaseEntity
    {
        public int? RiskAssessmentTypeId { get; set; }
        public int? RiskDescriptionId { get; set; }
        public string Guidance { get; set; }
        public string RelatedLegislation { get; set; }
        public int? LocationId { get; set; }
        public DateTime? IdentifiedOn { get; set; }
        public System.DateTime DateAdded { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int RiskTypeId { get; set; } 
        public int? HazardId { get; set; }
                
        public Nullable<int> ControlId { get; set; }
        public string RiskDataId { get; set; }
        public Nullable<int> RiskStatusId { get; set; }
        public Nullable<int> RiskPriorityId { get; set; }
        public Nullable<int> TopicId { get; set; }
        public short RiskRatingValue { get; set; }
        public Nullable<bool> IsVaultRisk { get; set; }
        public Nullable<bool> IsControlledRisk { get; set; }
        public Nullable<System.DateTime> ControlledOn { get; set; }
        public bool IsArchived { get; set; } = false;
        public Nullable<bool> IsAssociatedAssessmentPublished { get; set; }
    }
}
