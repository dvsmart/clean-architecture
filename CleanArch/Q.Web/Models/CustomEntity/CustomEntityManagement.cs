﻿using System.Collections.Generic;

namespace Q.Web.Controllers.CustomEntity
{
    public class CustomEntityManagement
    {
        public List<Group> Groups { get; set; }
    }
    public class Group
    {
        public int GroupId { get; set; }

        public string Name { get; set; }

        public List<Template> Templates { get; set; }

    }

    public class Template
    {
        public int TemplateId { get; set; }

        public string TemplateName { get; set; }

        public List<Tab> Tabs { get; set; }
    }

    public class Tab
    {
        public int TabId { get; set; }

        public string TabName { get; set; }

        public List<Field> Fields { get; set; }

    }

    public class Field
    {
        public int FieldId { get; set; }

        public string Caption { get; set; }
    }
}
