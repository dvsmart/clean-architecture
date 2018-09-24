using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Q.Web.Models.Base;

namespace Q.Web.Models.Event
{
    public class EventModel : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public int? RecurrenceTypeId { get; set; }

        public bool AllDayEvent { get; set; }

        public bool IsCompleted { get; set; }

        public string RecurrenceType { get; set; }
    }
}
