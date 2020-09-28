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
            Title = "Bleakwind Buffet";
        }

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
                uxOrder.AddOrder((IOrderItem)item);
            }
            ResetFrame();
            uxPageName.Content = "Menu";
        }
    }
}
