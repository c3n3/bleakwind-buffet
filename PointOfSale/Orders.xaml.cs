/*
 * Author: Caden Churchman
 * Class: Orders
 * Purpose: This is a list of all orders
 */
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        public Order Order { get; set; } = new Order();

        /// <summary>
        /// The orders
        /// </summary>
        public Orders()
        {
            InitializeComponent();
            DataContext = Order;
        }

        /// <summary>
        /// Update price
        /// </summary>
        public void UpdatePrice()
        {
            double total = 0;
            foreach (var a in uxOrderStack.Children)
            {
                total += ((OrderedItem)a).Value.Price;
            }
            //uxPrice.Content = $"Subtotal: {Math.Round(total, 2)}\nTax: {Math.Round(total * Constants.TAX, 2)}\n Total: {Math.Round(total + total * Constants.TAX, 2)}";
            Console.WriteLine(total);
        }

        /// <summary>
        /// The add order
        /// </summary>
        /// <param name="item"> the item </param>
        public void AddOrder(IOrderItem item)
        {
            var l = new OrderedItem(item.ToString(), item);
            l.uxTitle.HorizontalContentAlignment = HorizontalAlignment.Left;
            l.Deleted += DeleteOrder;
            uxOrderStack.Children.Add(l);
            UpdatePrice();
            Order.Add(item);
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

        public void DeleteOrder(object item, EventArgs e)
        {
            if (item is OrderedItem i)
            {
                uxOrderStack.Children.Remove(i);
                Order.Remove(i.Value);
                UpdatePrice();
            }
        }
    }
}
