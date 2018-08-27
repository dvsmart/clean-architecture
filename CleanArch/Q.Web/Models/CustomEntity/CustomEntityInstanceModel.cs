
using System;

namespace Q.Web.Models.CustomEntity
{
    public class CustomEntityInstanceModel
    {
        public int Id { get; set; }

        public string DataId { get; set; }

        public int CustomEntityId { get; set; }

        public int StatusId { get; set; }
    }

    public class CustomEntityInstanceGridModel
    {
        public string DataId { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; }

        public int Id { get; set; }
    }

    public class CustomEntityRecord
    {
        public int  Id  { get; set; }

        public string DataId { get; set; }

        public int CustomEntityId { get; set; }

        public CustomTabModel TabFieldsModel { get; set; }
    }
}
