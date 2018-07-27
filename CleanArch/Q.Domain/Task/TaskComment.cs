using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.Task
{
    public class TaskComment : BaseEntity
    {
        public string Comments { get; set; }

        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
