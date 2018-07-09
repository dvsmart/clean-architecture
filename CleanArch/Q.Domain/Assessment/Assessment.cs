﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.Assessment
{
    public class Assessment : BaseEntity
    {
        public string Title { get; set; }

        public string Reference { get; set; }

        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

        public int? PublishedBy { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int AssessmentTypeId { get; set; }

        public virtual AssessmentType AssessmentType { get; set; }

        public virtual AssessmentScope AssessmentScope { get; set; }
    }
}