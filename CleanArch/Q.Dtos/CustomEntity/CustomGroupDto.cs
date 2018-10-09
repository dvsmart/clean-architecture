using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Dtos.CustomEntity
{
    public class CustomGroupDto
    {
        public CustomGroupDto()
        {
            Templates = new List<CustomDto>();
        }

        public int Id { get; set; }

        public string GroupName { get; set; }

        public List<CustomDto> Templates { get; set; }
    }

    public class CreateCustomGroupDto
    {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public bool IsVisible { get; set; }

    }

    public class CustomTemplateDto
    {
        public int Id { get; set; }

        public string TemplateName { get; set; }

    }

    public class CustomTemplateTabDto
    {

        public CustomTemplateTabDto()
        {
            TemplateTabs = new List<CustomDto>();
        }

        public int Id { get; set; }

        public string TemplateName { get; set; }

        public List<CustomDto> TemplateTabs { get; set; }

    }

    public class CustomTemplateTabFieldsDto
    {
        public int Id { get; set; }

        public string TabName { get; set; }

        public List<CustomTabFieldDto> CustomTabFields { get; set; }
    }
    

    public class CustomDto
    {
        public int Id { get; set; }

        public string Caption { get; set; }
    }




    [Obsolete("To be used in Template Form")]
    public class CustomTabFieldDto
    {

        public int Id { get; set; }

        public string Key { private get { return Key; } set => value = $"field_{Id}"; }

        public string Caption { get; set; }

        public bool IsVisible { get; set; }

        public bool IsRequired { get; set; }

        public int ControlType { get; set; }

        public List<CustomFieldOption> CustomFieldOptions { get; set; }

    }

    public class CreateCustomTabFieldRequest
    {

        public int Id { get; set; } = default(int);

        public string Caption { get; set; }

        public bool IsVisible { get; set; }

        public bool IsRequired { get; set; }

        public int ControlType { get; set; }

        public List<CustomFieldOption> CustomFieldOptions { get; set; }

    }



    public class CustomFieldOption
    {
        public int Id { get; set; }

        public string Option { get; set; }

        public bool IsSelected { get; set; } = false;
    }
}
