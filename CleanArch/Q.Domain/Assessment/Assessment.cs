using Q.Domain.Common;
using Q.Domain.Task;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q.Domain.Assessment
{
    public class Assessment : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DataId { get { return "AM" + Id.ToString(); } private set { } }
        public string Title { get; set; }

        public string Reference { get; set; }

        public int? PublishedBy { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int TypeId { get; set; }

        public int ScopeId { get; set; }

        public DateTime? AssessmentDate { get; set; }

        public int? FrequencyId { get; set; }

        public bool IsSuperseded { get; set; }

        public int? AssessorUserId { get; set; }

        public virtual AssessmentType AssessmentType { get; set; }

        public virtual AssessmentScope AssessmentScope { get; set; }

        public virtual RecurrenceType RecurrenceType { get; set; }
    }
}
