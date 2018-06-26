using Q.Domain.Menu;
using System.Collections.Generic;
using System.Linq;

namespace Q.Web.Models
{
    public class MenuModel : BaseModel
    {
        public string Caption { get; set; }

        public string Route { get; set; }

        public bool HasChildren { get; set; }

        public string ClassName { get; set; }

        public string IconName { get; set; }

        public bool IsVisible { get; set; }

        public int SortOrder { get; set; }

        public int MenuGroupId { get; set; }
        public int? ParentId { get; set; }

        public List<MenuModel> Children { get; set; }

        public static List<MenuModel> GetMenuItems(List<MenuItem> menuItems, bool? isChild)
        {
            var menuList = new List<MenuModel>();

            foreach (var item in menuItems)
            {
                if(item.ParentId == null || (isChild.HasValue && isChild.Value))
                {
                    menuList.Add(new MenuModel
                    {
                        AddedDate = item.AddedDate,
                        Caption = item.Caption,
                        Route = item.Route,
                        IconName = item.IconName,
                        ClassName = item.ClassName,
                        HasChildren = item.HasChildren,
                        IsVisible = item.IsVisible,
                        SortOrder = item.SortOrder,
                        MenuGroupId = item.MenuGroupId,
                        ParentId = item.ParentId,
                        Id = item.Id,
                        Children = item.HasChildren ? GetMenuItems(item.Children.ToList(), true) : null
                    });
                }
            }

            return menuList;
        }

        //private static List<MenuModel> GetChildMenu(List<MenuItem> menuItems)
        //{
        //    var menuList = new List<MenuModel>();

        //    foreach (var item in menuItems)
        //    {
        //        menuList.Add(new MenuModel
        //        {
        //            AddedDate = item.AddedDate,
        //            Caption = item.Caption,
        //            Route = item.Route,
        //            IconName = item.IconName,
        //            ClassName = item.ClassName,
        //            HasChildren = item.HasChildren,
        //            IsVisible = item.IsVisible,
        //            SortOrder = item.SortOrder,
        //            MenuGroupId = item.MenuGroupId,
        //            ParentId = item.ParentId,
        //            Children = item.HasChildren ? GetChildMenu(item.Children.ToList()) : null
        //        });
        //    }
        //    return menuList;
        //}
    }
}
