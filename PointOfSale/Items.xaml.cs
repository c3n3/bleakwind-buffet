using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : UserControl
    {
        public event EventHandler ItemClicked;

        /// <summary>
        /// The Items to choose from. Bassically the menu.
        /// </summary>
        public Items()
        {
            InitializeComponent();
            foreach (var a in BleakwindBuffet.Data.Menu.Menu.EntreeItems())
            {
                var item = new Item(a.ToString(), a);
                uxEntrees.Children.Add(item);
                item.Clicked += new EventHandler(SendItem);
            }
            foreach (var a in BleakwindBuffet.Data.Menu.Menu.DrinkItems())
            {
                //TODO: Use actual method for name, not this jank stuff.
                var item = new Item(Regex.Replace(a.GetType().Name, "([A-Z])", " $1"), a);
                uxDrinks.Children.Add(item);
                item.Clicked += new EventHandler(SendItem);
            }
            foreach (var a in BleakwindBuffet.Data.Menu.Menu.SideItems())
            {
                //TODO: Use actual method for name, not this jank stuff.
                var item = new Item(Regex.Replace(a.GetType().Name, "([A-Z])", " $1"), a);
                uxSides.Children.Add(item);
                item.Clicked += new EventHandler(SendItem);
            }
        }

        /// <summary>
        /// Sends out an item to the top level
        /// </summary>
        /// <param name="sender"> The Item </param>
        /// <param name="m"> The args s</param>
        public void SendItem(object sender, EventArgs m)
        {
            ItemClicked(((Item)sender).Value, new EventArgs());
        }
    }
}
