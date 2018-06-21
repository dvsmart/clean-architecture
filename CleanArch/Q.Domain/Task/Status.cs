using System.Collections.Generic;

namespace Q.Domain.Task
{
    public class TaskStatus : BaseEntity
    {
        public string Name { get; set; }
       
        public bool? IsActive { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
