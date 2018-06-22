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

        public string Status { get; set; }

        public string Priority { get; set; }
    }

    public class TaskListModel: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }
    }
}
