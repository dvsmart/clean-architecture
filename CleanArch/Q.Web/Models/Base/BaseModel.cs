using System;

namespace Q.Web.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }

        public string DataId { get; set; }
    }
}
