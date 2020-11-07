/*
* Author: Caden Churchman
* Class name: Index.cshtml.cs
* Purpose: Handles the webpage.
*/
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
    /// <summary>
    /// The index model
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// No idea
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// No idea
        /// </summary>
        /// <param name="logger"> the logger </param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            RefreshItems();

        }

        /// <summary>
        /// Refreshes that funky dictionary
        /// </summary>
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

        /// <summary>
        /// The item type
        /// </summary>
        public string[] ItemType = new string[] {"Drinks", "Entrees", "Sides"};

        /// <summary>
        /// This is the text search
        /// </summary>
        public string Text = "";

        /// <summary>
        /// This holds all the items
        /// </summary>
        public Dictionary<string,Dictionary<string,List<IOrderItem>>> items = new Dictionary<string, Dictionary<string, List<IOrderItem>>>()
        {
            {"Drinks", null },
            {"Sides", null },
            {"Entrees", null }
        };

        /// <summary>
        /// The cal min
        /// </summary>
        public double? CalMin;

        /// <summary>
        /// The cal max
        /// </summary>
        public double? CalMax;

        /// <summary>
        /// The min
        /// </summary>
        public double? PriceMin;

        /// <summary>
        /// The max
        /// </summary>
        public double? PriceMax;

        /// <summary>
        /// Checkboxes
        /// </summary>
        public Dictionary<string, bool> Checkboxes = new Dictionary<string, bool> { { "Drinks", true }, { "Entrees", true }, { "Sides", true } };

        /// <summary>
        /// Called when form submitted
        /// </summary>
        /// <param name="ItemType"> The item type </param>
        /// <param name="CalMax"> the max calories </param>
        /// <param name="CalMin"> the calories mininimin</param>
        /// <param name="PriceMin"> the price </param>
        /// <param name="PriceMax"> the price max</param>
        /// <param name="text"> the text searched</param>
        public void OnGet(string[] ItemType, double? CalMax, double? CalMin, double? PriceMin, double? PriceMax, string text)
        {
            RefreshItems();
            Text = text;
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
                    if (text != null) items[type][itemName] = items[type][itemName].Where(x => x.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase)).ToList(); 
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
