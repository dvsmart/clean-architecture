using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.Menu
{
    public class MenuGroup : BaseEntity
    {
        public string Name { get; set; }

        public bool IsVisible { get; set; }

        public List<MenuItem> MenuItems { get; set; }

    }
}
