/*
 * Author: Caden Churchman
 * Class: MainWindow
 * Purpose: Main window
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Menu;
using PointOfSale.PayMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private Window _popup;

        /// <summary>
        /// Help to keep things from leaking
        /// </summary>
        private void CleanFrameEvents()
        {
            if (uxMainFrame.Content is AddItem a)
            {
                a.Result -= AddResult;
            } else if (uxMainFrame.Content is Items i)
            {
                i.ItemClicked -= ItemClicked;
            } else if (uxMainFrame.Content is ComboMenu c)
            {
                c.OutFunc -= AddResult;
            }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            uxOrder.Pay += Pay;
            ResetFrame();
            uxPageName.Content = "Menu";
            Title = "Bleakwind Buffet - 8K Gold Edition - Adobe RGB 125% - Premium Expansion Pack - 2029 World Series Champs - New York Times #1 Best Seller";
        }

        
        /// <summary>
        /// Pay from the popup
        /// </summary>
        /// <param name="order"></param>
        /// <param name="e"></param>
        public void Pay(object order, EventArgs e)
        {
            var b = new PopupPayment(uxOrder.Order);
            _popup = new Window();
            b.Result += PopupResult;
            _popup.Closed += PopupClosed;
            _popup.Content = b;
            _popup.Top = Top;
            _popup.Left = Left;
            IsEnabled = false;
            _popup.ShowDialog();
        }

        /// <summary>
        /// Popup closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PopupClosed(object sender, EventArgs e)
        {
            ((PopupPayment)_popup.Content).Result -= PopupResult;
            _popup.Closed -= PopupClosed;
            IsEnabled = true;
            _popup = null;
        }

        /// <summary>
        /// Result of payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PopupResult(object sender, EventArgs e)
        {
            if (e is PopupPaymentResultArgs p)
            {
                IsEnabled = true;
                ((PopupPayment)_popup.Content).Result -= PopupResult;
                _popup.Close();
                _popup = null;
                if (p.result != PopupPaymentResultArgs.ResultType.CANCEL)
                {
                    uxOrder.NewOrder();
                } 
            }
        }

        private int _editIndex = -1;

        /// <summary>
        /// Reset the frame.
        /// </summary>
        public void ResetFrame()
        {
            CleanFrameEvents();
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
        public void ItemClicked(object itemN, EventArgs e)
        {
            CleanFrameEvents();
            if (itemN is Combo c)
            {
                var addPage = new ComboMenu(c);
                addPage.OutFunc += AddResult;
                uxMainFrame.Content = addPage;
                uxPageName.Content = "COMBO!";
            }
            else if (itemN is IOrderItem item)
            {
                var addPage = new AddItem(item);
                addPage.Result += new EventHandler(AddResult);
                uxMainFrame.Content = addPage;
                uxPageName.Content = "Add / Edit Item";
            }
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
                    //uxOrder.Change((IOrderItem)item, _editIndex);
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
            if (((ItemEventArgs)e).item is Combo c)
            {
                var addPage = new ComboMenu(c);
                uxMainFrame.Content = addPage;
                uxPageName.Content = "Edit Combo";
                addPage.OutFunc += AddResult;

            } else
            {
                var addPage = new AddItem(((ItemEventArgs)e).item);
                addPage.Result += new EventHandler(AddResult);
                uxMainFrame.Content = addPage;
                uxPageName.Content = "Add / Edit Item";
            }
        }

        /// <summary>
        /// Window closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            _popup?.Close();
        }
    }
}
