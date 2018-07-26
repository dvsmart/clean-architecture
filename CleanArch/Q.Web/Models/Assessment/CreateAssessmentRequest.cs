using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Web.Models.Assessment
{
    public class CreateAssessmentRequest : BaseModel
    {
        public string Title { get; set; }
        public DateTime? AssessmentDate { get; set; }

        public int AssessmentTypeId { get; set; }

        public string Reference { get; set; }

        public int? ScopeId { get; set; }

        public bool Published { get; set; }
    }
}
