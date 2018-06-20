using Q.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Service.UseCases.Task
{
    public class TaskDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public int Status { get; set; }

        public int Priority { get; set; }
    }
}
