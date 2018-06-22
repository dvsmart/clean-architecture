using System;

namespace Q.Domain.Task
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public int TaskStatusId { get; set; }

        public int TaskPriorityId { get; set; }

        public virtual TaskStatus TaskStatus { get; set; }

        public virtual TaskPriority TaskPriority { get; set; }

    }
}
