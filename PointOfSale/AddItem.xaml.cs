/*
 * Author: Caden Churchman
 * Class: AddItem
 * Purpose: Makes the menu to edit an item to add
 */
using BleakwindBuffet.Data.Menu;
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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : UserControl
    {
        /// <summary>
        /// The result event handler
        /// </summary>
        public event EventHandler Result;

        /// <summary>
        /// This is the item
        /// </summary>
        private IOrderItem _item;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="item"> Item to add. </param>
        public AddItem(IOrderItem item)
        {
            InitializeComponent();
            _item = item;
            DataContext = _item;
            //TODO: Replace the jank name thing.
            uxItemTitle.Content = Regex.Replace(_item.GetType().Name, "([A-Z])", " $1");
            foreach (string option in _item.BoolOptions)
            {
                var checkbox = new CustomCheckBox(option, (bool)_item[option]);
                checkbox.Switched += CheckboxSwitchedEventListener;
                uxBoolOptions.Children.Add(checkbox);
            }
            foreach (KeyValuePair<string, List<object>> option in _item.EnumOptions)
            {
                var border = new Border();
                border.Margin = new Thickness(15, 15, 15, 15);
                Grid.SetZIndex(border, 1000);
                var combo = new Selector(option.Value, option.Value[0], option.Key);
                combo.Selected += AddSelector;
                border.Child = combo;
                uxEnumOptions.Children.Add(border);
            }
        }

        /// <summary>
        /// When the selector sends out a selected event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddSelector(object sender, EventArgs e)
        {
            if (sender is Selector s)
            {
                _item[s.Key] = s.Value;
                uxItemTitle.Content = _item.ToString();
            }
        }

        /// <summary>
        /// Cancel the add.
        /// </summary>
        /// <param name="sender"> The sender </param>
        /// <param name="e"> The args </param>
        private void uxCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result(null, null);
        }

        /// <summary>
        /// Add button.
        /// </summary>
        /// <param name="sender"> The sender </param>
        /// <param name="e"> The args </param>
        private void uxAddButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var combo in uxEnumOptions.Children)
            {
                _item[(((Selector)((Border)combo).Child)).Key] = ((Selector)(((Border)combo).Child)).Value;
            }
            foreach (var checkbox in uxBoolOptions.Children)
            {
                _item[((CustomCheckBox)(checkbox)).Value] = ((CustomCheckBox)(checkbox)).On;
            }
            Result(_item, null);
        }

        /// <summary>
        /// When the checkbox is switched
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckboxSwitchedEventListener(object sender, EventArgs e)
        {
            if (e is CheckboxEventArgs args)
            {
                _item[args.Option] = args.On;
            }
        }
    }
}
