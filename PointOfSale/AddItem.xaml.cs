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

        private IOrderItem _item;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="item"> Item to add. </param>
        public AddItem(IOrderItem item)
        {
            InitializeComponent();
            _item = item;
            //TODO: Replace the jank name thing.
            uxItemTitle.Content = Regex.Replace(_item.GetType().Name, "([A-Z])", " $1");
            foreach (string option in _item.BoolOptions)
            {
                var checkbox = new CheckBox();
                checkbox.FontSize = 15;
                checkbox.Content = option;
                checkbox.IsChecked = (bool)_item[option];
                uxBoolProps.Children.Add(checkbox);
            }
            foreach (KeyValuePair<string, List<object>> option in _item.EnumOptions)
            {
                var combo = new ComboBox();
                combo.FontSize = 15;
                combo.Tag = option.Key;
                combo.SelectedIndex = option.Value.IndexOf(_item[option.Key]);
                combo.ItemsSource = option.Value;
                uxEnumProps.Children.Add(combo);
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
            foreach (var combo in uxEnumProps.Children)
            {
                _item[(string)((ComboBox)combo).Tag] = ((ComboBox)combo).SelectedItem;
            }
            foreach (var checkbox in uxBoolProps.Children)
            {
                _item[(string)((CheckBox)checkbox).Content] = ((CheckBox)checkbox).IsChecked;
            }
            Result(_item, null);
        }
    }
}
