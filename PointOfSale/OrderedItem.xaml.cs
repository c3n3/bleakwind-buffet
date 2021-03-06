﻿/*
 * Author: Caden Churchman
 * Class: OrderedItem
 * Purpose: Represents an item on the orders list
 */
using BleakwindBuffet.Data.Entrees;
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
    public partial class OrderedItem : UserControl
    {
        /// <summary>
        /// This is the special instructions property
        /// </summary>
        public static readonly DependencyProperty SpecialInstructionsProp = DependencyProperty.Register("SpecialInstructions", typeof(List<string>), typeof(OrderedItem), new FrameworkPropertyMetadata(new List<string>()));

        /// <summary>
        /// This is the TitleProp
        /// </summary>
        public static readonly DependencyProperty TitleProp = DependencyProperty.Register("Title", typeof(string), typeof(OrderedItem), new FrameworkPropertyMetadata(""));

        /// <summary>
        /// This is the price dependancy property
        /// </summary>
        public static readonly DependencyProperty PriceProp = DependencyProperty.Register("Price", typeof(string), typeof(OrderedItem), new FrameworkPropertyMetadata(""));

        /// <summary>
        /// This is the SpecialInstruction
        /// </summary>
        public List<string> SpecialInstructions { get; set; }

        /// <summary>
        /// Price Property
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// The cl
        /// </summary>
        public event EventHandler Deleted;

        /// <summary>
        /// The value in terms of an item
        /// </summary>
        public IOrderItem Value { get; set; }

        /// <summary>
        /// Default Ctor
        /// </summary>
        public OrderedItem()
        {
            InitializeComponent();
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
            Deleted(DataContext, null);
        }
    }
}
