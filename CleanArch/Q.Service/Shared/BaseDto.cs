using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Service.Shared
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
