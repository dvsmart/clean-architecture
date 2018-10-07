using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.CustomEntity
{
    public class CustomEntityDto
    {
        public int Id { get; set; }

        public string TemplateName { get; set; }
    }


    public class CustomEntityGroupDto
    {
        public CustomEntityGroupDto()
        {
            CustomEntities = new List<CustomEntityDto>();
        }

        public int Id { get; set; }

        public string GroupName { get; set; }

        public int Count { get { return CustomEntities.Count; } private set { } }

        public List<CustomEntityDto> CustomEntities { get; set; }
    }


}
