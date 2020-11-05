using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            RefreshItems();

        }

        private void RefreshItems()
        {
            for (int i = 0; i < items.Keys.Count; i++)
            {
                var key = items.Keys.ToList()[i];
                items[key] = new Dictionary<string, List<IOrderItem>>();
                foreach (var item in key == "Drinks" ? Menu.DrinksWithoutTheStupidIterationsOfSailorSoda() : key == "Entrees" ? Menu.Entrees() : Menu.Sides())
                {
                    if (items[key].ContainsKey(Menu.GetMenuName(item)))
                    {
                        items[key][Menu.GetMenuName(item)].Add(item);
                    } else
                    {
                        items[key].Add(Menu.GetMenuName(item), new List<IOrderItem>() { item });
                    }
                }
            }
        }

        public string[] ItemType = new string[] {"Drinks", "Entrees", "Sides"};

        public Dictionary<string,Dictionary<string,List<IOrderItem>>> items = new Dictionary<string, Dictionary<string, List<IOrderItem>>>()
        {
            {"Drinks", null },
            {"Sides", null },
            {"Entrees", null }
        };

        public double? CalMin;
        public double? CalMax;

        public double? PriceMin;
        public double? PriceMax;

        public Dictionary<string, bool> Checkboxes = new Dictionary<string, bool> { { "Drinks", true }, { "Entrees", true }, { "Sides", true } };

        public void OnGet(string[] ItemType, double? CalMax, double? CalMin, double? PriceMin, double? PriceMax)
        {
            RefreshItems();
            if (Request.Query.Count == 0) return;
            for (int j = 0; j < items.Keys.Count; j++)
            {
                var type = items.Keys.ToList()[j];
                for (int i = 0; i < items[type].Keys.Count; i++)
                {
                    var itemName = items[type].Keys.ToList()[i];
                    if (PriceMin != null) items[type][itemName] = items[type][itemName].Where(x => x.Price >= PriceMin).ToList();
                    if (PriceMax != null) items[type][itemName] = items[type][itemName].Where(x => x.Price <= PriceMax).ToList();
                    if (CalMax != null) items[type][itemName] = items[type][itemName].Where(x => x.Calories <= CalMax).ToList(); 
                    if (CalMin != null) items[type][itemName] = items[type][itemName].Where(x => x.Calories >= CalMin).ToList(); 
                }
            }

            this.ItemType = ItemType == null ? this.ItemType : ItemType;
            this.CalMax = CalMax;
            this.CalMin = CalMin;
            this.PriceMax = PriceMax;
            this.PriceMin = PriceMin;
        }
    }
}
