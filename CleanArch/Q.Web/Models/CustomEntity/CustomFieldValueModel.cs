
using System.Collections.Generic;

namespace Q.Web.Models.CustomEntity
{
    public class CustomFieldValueModel
    {
        public int CustomEntityInstanceId { get; set; }

        public int CustomFieldId { get; set; }

        public string Value { get; set; }
    }

    public class Field
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }

    public class CreateFieldValueRequest
    {
        public List<Field> FieldValues { get; set; }

        public int CustomEntityValueId { get; set; }
    }
}
