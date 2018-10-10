using System.Collections.Generic;

namespace Q.Domain.Assessment
{
    public class AssessmentScope : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
