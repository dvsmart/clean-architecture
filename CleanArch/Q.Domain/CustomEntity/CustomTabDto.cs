using System.Collections.Generic;

namespace Q.Domain.CustomEntity
{
    public class CustomTabDto
    {
        public CustomTabDto()
        {
            CustomFields = new List<CustomFieldDto>();
        }

        public int TabId { get; set; }

        public string Caption { get; set; }

        public short? SortOrder { get; set; }

        public bool IsVisible { get; set; }

        public IEnumerable<CustomFieldDto> CustomFields { get; set; }
    }
}
