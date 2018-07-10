﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Web.Models.Assessment
{
    public class AssessmentListModel : BaseModel
    {
        public string Title { get; set; }

        public string Reference { get; set; }

        public string AssessmentType { get; set; }

        public string AssessmentScope { get; set; }

        private string PublishedBy { get; set; }

        public DateTime? PublishedDate { get; set; }

        private string Status { get; set; }
    }
}
