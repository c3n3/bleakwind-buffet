/*
 * Author: Caden Churchman
 * Class: MainWindow
 * Purpose: Main window
 */
using BleakwindBuffet.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ResetFrame();
            uxPageName.Content = "Menu";
            Title = "Bleakwind Buffet - 8K Gold Edition - Adobe RGB 125% - Premium Extension Pack";
        }

        private int _editIndex = -1;

        /// <summary>
        /// Reset the frame.
        /// </summary>
        public void ResetFrame()
        {
            var page = new Items();
            uxMainFrame.Content = page;
            uxMainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            page.ItemClicked += new EventHandler(ItemClicked);
        }

        /// <summary>
        /// What happens when an item is clicked
        /// </summary>
        /// <param name="item"> The item </param>
        /// <param name="e"> the args </param>
        public void ItemClicked(object item, EventArgs e)
        {
            var addPage = new AddItem((IOrderItem)item);
            addPage.Result += new EventHandler(AddResult);
            uxMainFrame.Content = addPage;
            uxPageName.Content = "Add / Edit Item";
        }

        /// <summary>
        /// Event handler to add a result.
        /// </summary>
        /// <param name="item"> The item</param>
        /// <param name="e"> The event args </param>
        public void AddResult(object item, EventArgs e)
        {
            if (item != null)
            {
                if (_editIndex != -1)
                {
                    uxOrder.Change((IOrderItem)item, _editIndex);
                } else
                {
                    uxOrder.AddOrder((IOrderItem)item);
                }
            }
            _editIndex = -1;
            ResetFrame();
            uxPageName.Content = "Menu";
        }

        /// <summary>
        /// This is the uxOrder edit event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOrder_EditItem(object sender, EventArgs e)
        {
            _editIndex = ((ItemEventArgs)e).index;
            var addPage = new AddItem(((ItemEventArgs)e).item);
            addPage.Result += new EventHandler(AddResult);
            uxMainFrame.Content = addPage;
            uxPageName.Content = "Add / Edit Item";
        }
    }
}
