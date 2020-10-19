/*
 * Author: Caden Churchman
 * Class: ComboMenu
 * Purpose: Choose items in combo
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
    /// Interaction logic for ComboMenu.xaml
    /// </summary>
    public partial class ComboMenu : UserControl
    {
        public event EventHandler OutFunc;
        
        public ComboScreen _page;
        public ComboMenu(Combo c)
        {
            InitializeComponent();
            _page = new ComboScreen(c);
            uxComboFrame.Content = _page;
            _page.Done += DoneWithCombo;
            _page.EditItem += EditItem;
            uxComboFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        /// <summary>
        /// Edit item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EditItem(object sender, EventArgs e)
        {
            if (sender is IOrderItem item)
            {
                var a = new AddItem(item);
                a.Result += DoneEdit;
                uxComboFrame.Content = a;
            }
        }

        /// <summary>
        /// Done edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoneEdit(object sender, EventArgs e)
        {
            ((AddItem)uxComboFrame.Content).Result -= DoneEdit;
            uxComboFrame.Content = _page;
        }

        /// <summary>
        /// Done with combo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoneWithCombo(object sender, EventArgs e)
        {
            OutFunc?.Invoke(sender, null);
        }

    }
}
