using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        /// <summary>
        /// The orders
        /// </summary>
        public Orders()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update price
        /// </summary>
        public void UpdatePrice()
        {
            double total = 0;
            foreach (var a in uxOrderStack.Children)
            {
                total += ((Item)a).Value.Price;
            }
            uxPrice.Content = $"Price: \n\t{total}";
            Console.WriteLine(total);
        }

        /// <summary>
        /// The add order
        /// </summary>
        /// <param name="item"> the item </param>
        public void AddOrder(IOrderItem item)
        {
            var l = new Item(item.ToString() + $" {item.Price}", item);
            l.uxTitle.HorizontalContentAlignment = HorizontalAlignment.Left;
            uxOrderStack.Children.Add(l);
            UpdatePrice();
        }

        /// <summary>
        /// Click handler
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> event </param>
        private void uxClearOrders_Click(object sender, RoutedEventArgs e)
        {
            uxOrderStack.Children.Clear();
            UpdatePrice();
        }
    }
}
