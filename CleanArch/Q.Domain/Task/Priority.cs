using System.Collections.Generic;

namespace Q.Domain.Task
{
    public class TaskPriority : BaseEntity
    {
        public string Name { get; set; }

        public List<Task> Tasks { get; set; }
    }
}