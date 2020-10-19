/*
 * Author: Caden Churchman
 * Class: ComboScreen
 * Purpose: Lists all items
 */
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Sides;
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
    /// Interaction logic for ComboScreen.xaml
    /// </summary>
    public partial class ComboScreen : Page
    {
        private Combo _combo;

        /// <summary>
        /// Edit item
        /// </summary>
        public event EventHandler EditItem;

        /// <summary>
        /// When done
        /// </summary>
        public event EventHandler Done;

        /// <summary>
        /// Is combo valid
        /// </summary>
        private void CheckValidCombo()
        {
            uxDone.IsEnabled = !(_combo.Entree == null || _combo.Drink == null || _combo.Side == null);
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="c"></param>
        public ComboScreen(Combo c)
        {
            InitializeComponent();
            _combo = c;
            CheckValidCombo();
            DataContext = _combo;
            foreach (var item in BleakwindBuffet.Data.Menu.Menu.DrinkItems())
            {
                var radio = new RadioButton
                {
                    GroupName = "drinks"
                };
                radio.Checked += RadioPressed;
                radio.IsChecked = _combo.Drink == null ? false : _combo.Drink.GetType().Name == item.GetType().Name; 
                radio.Content = Regex.Replace(item.GetType().Name, "([A-Z])", " $1");
                radio.Margin = new Thickness(10, 10, 10, 10);
                radio.FontStretch = FontStretches.Expanded;
                radio.Foreground = Brushes.WhiteSmoke;
                var border = new Border
                {
                    Margin = new Thickness(10, 10, 10, 0),
                    BorderBrush = Brushes.WhiteSmoke,
                    BorderThickness = new Thickness(2),
                    Child = radio
                };
                radio.Tag = item;
                uxDrinks.Children.Add(border);
            }
            foreach (var item in BleakwindBuffet.Data.Menu.Menu.EntreeItems())
            {
                var radio = new RadioButton();
                radio.Checked += RadioPressed;
                radio.IsChecked = _combo.Entree == null ? false : _combo.Entree.GetType().Name == item.GetType().Name; 
                radio.GroupName = "entrees";
                radio.Content = Regex.Replace(item.GetType().Name, "([A-Z])", " $1");
                radio.Margin = new Thickness(10, 10, 10, 10);
                radio.FontStretch = FontStretches.Expanded;
                radio.Foreground = Brushes.WhiteSmoke;
                var border = new Border();
                border.Margin = new Thickness(10, 10, 10, 0);
                border.BorderBrush = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(2);
                border.Child = radio;
                radio.Tag = item;
                uxEntrees.Children.Add(border);
            }
            foreach (var item in BleakwindBuffet.Data.Menu.Menu.SideItems())
            {
                var radio = new RadioButton();
                radio.Checked += RadioPressed;
                radio.IsChecked = _combo.Side == null ? false : _combo.Side.GetType().Name == item.GetType().Name; 
                radio.GroupName = "sides";
                radio.Content = Regex.Replace(item.GetType().Name, "([A-Z])", " $1");
                radio.Margin = new Thickness(10, 10, 10, 10);
                radio.FontStretch = FontStretches.Expanded;
                radio.Foreground = Brushes.WhiteSmoke;
                var border = new Border();
                border.Margin = new Thickness(10, 10, 10, 0);
                border.BorderBrush = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(2);
                border.Child = radio;
                radio.Tag = item;
                uxSides.Children.Add(border);
            }
        }

        /// <summary>
        /// When radio pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RadioPressed(object sender, EventArgs e)
        {
            if (sender is RadioButton r && r.Tag is IOrderItem item)
            {
                switch (r.GroupName)
                {
                    case "sides":
                        _combo.Side = (Side)item;
                        break;

                    case "drinks":
                        _combo.Drink = (Drink)item;
                        break;

                    case "entrees":
                        _combo.Entree = (Entree)item;
                        break;
                }
                EditItem?.Invoke(item, null);
            }
            CheckValidCombo();
        }

        /// <summary>
        /// The uxDone lcick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDone_Click(object sender, RoutedEventArgs e)
        {
            Done?.Invoke(_combo, null);
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            Done?.Invoke(null, null);
        }
    }
}
