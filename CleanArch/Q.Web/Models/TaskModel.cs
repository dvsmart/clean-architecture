using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Web.Models
{
    public class TaskModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public int TaskStatusId { get; set; }

        public int TaskPriorityId { get; set; }
    }

    public enum TaskStatus
    {
        InProgress = 1,
        NotStarted = 2,
        OnHold = 3,
        Completed = 4,
        Abandoned = 5
    }

    public enum TaskPriority
    {
        Low = 1,
        Minor = 2,
        Moderate = 3,
        High = 4,
        Urgent = 5,
    }
}
