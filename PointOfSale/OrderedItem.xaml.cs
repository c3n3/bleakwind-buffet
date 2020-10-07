/*
 * Author: Caden Churchman
 * Class: OrderedItem
 * Purpose: Represents an item on the orders list
 */
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
    /// Interaction logic for OrderedItem.xaml
    /// </summary>
    public partial class OrderedItem
    {
        /// <summary>
        /// The cl
        /// </summary>
        public event EventHandler Deleted;

        /// <summary>
        /// The value in terms of an item
        /// </summary>
        public IOrderItem Value { get; private set; }

        /// <summary>
        /// Represents a graphical IOrderItem
        /// </summary>
        /// <param name="title"> The title </param>
        /// <param name="item"> The item of the thing </param>
        public OrderedItem(string title, IOrderItem item)
        {
            InitializeComponent();
            string t = "";
            this.DataContext = item;
            foreach (var opt in item.SpecialInstructions)
            {
                t += "\n\t" + opt;
            }
            uxInfo.Content = t;
            uxTitle.Content = title;
            Value = item;
        }

        /// <summary>
        /// Click on the item
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="m"> the args </param>
        public void Left_Click(object sender, MouseButtonEventArgs m)
        {
            if (Deleted == null) return;
            Deleted(this, new EventArgs());
        }

        /// <summary>
        /// When the mouse enters the thing we need to see the x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            uxEx.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// When it leaves hide the x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            uxEx.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// When the mouse clickes the x delete the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Deleted(this, null);
        }
    }
}
