using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnusSite.Models.General
{
    public class MenuModel
    {
        public MenuModel()
        {
            Items = new List<MenuItemModel>();
        }
        public MenuModel(List<MenuItemModel> items)
        {
            Items = items;
        }
        public string Title { get; set; }
        public List<MenuItemModel> Items { get; set; }        
    }

    public class MenuItemModel
    {
        public string Name { get; set; }
        public string Reference { get; set; }
    }
}