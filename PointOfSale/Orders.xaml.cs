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
        /// <summary>
        /// This is the order of the menu system
        /// </summary>
        public Order Order { get; set; } = new Order();

        /// <summary>
        /// This is the event handler of the edit item
        /// </summary>
        public event EventHandler EditItem;

        public event EventHandler Pay;

        /// <summary>
        /// The orders
        /// </summary>
        public Orders()
        {
            InitializeComponent();
            DataContext = Order;
        }

        public void NewOrder()
        {
            Order = new Order();
            DataContext = Order;
        }

        /// <summary>
        /// Update price
        /// </summary>
        public void UpdatePrice()
        { 
            //DEPRICATED
        }

        /// <summary>
        /// The add order
        /// </summary>
        /// <param name="item"> the item </param>
        public void AddOrder(IOrderItem item)
        {
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
            Order.Clear();
            UpdatePrice();
        }

        /// <summary>
        /// This deletes a order
        /// </summary>
        /// <param name="item"> the item </param>
        /// <param name="e"> this is the event </param>
        public void DeleteOrder(object item, EventArgs e)
        {
            if (item is IOrderItem i)
            {
                //uxOrderStack.Children.Remove(i);
                Order.Remove(i);
                UpdatePrice();
            }
        }

        /// <summary>
        /// This is the Change function
        /// </summary>
        /// <param name="item"> the item to change </param>
        /// <param name="index"> the index of the item </param>
        public void Change(IOrderItem item, int index)
        {
            Order.Replace(item, index);
        }

        /// <summary>
        /// This is the stack selected event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOrderStack_Selected(object sender, RoutedEventArgs e)
        {
            uxEditOrder.IsEnabled = true;
        }

        /// <summary>
        /// This is the unselect event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOrderStack_Unselected(object sender, RoutedEventArgs e)
        {
            uxEditOrder.IsEnabled = false;
        }

        /// <summary>
        /// This is the edit click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditOrder_Click(object sender, RoutedEventArgs e)
        {
            EditItem?.Invoke(this, new ItemEventArgs((IOrderItem)uxOrderStack.SelectedItem, uxOrderStack.SelectedIndex));
        }

        /// <summary>
        /// This makes the pay process start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPay_Click(object sender, RoutedEventArgs e)
        {
            if (Order.Count == 0)
            {
                return;
            }
            Pay?.Invoke(Order, null);
        }
    }
}
