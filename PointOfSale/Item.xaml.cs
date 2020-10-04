/*
 * Author: Caden Churchman
 * Class: Item
 * Purpose: Represents an item in a list
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
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item
    {
        /// <summary>
        /// The cl
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// The value in terms of an item
        /// </summary>
        public IOrderItem Value { get; private set; }

        /// <summary>
        /// Represents a graphical IOrderItem
        /// </summary>
        /// <param name="title"> The title </param>
        /// <param name="item"> The item of the thing </param>
        public Item(string title, IOrderItem item)
        {
            InitializeComponent();
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
            if (Clicked == null) return;
            Clicked(this, new EventArgs()); 
        }
    }
}
