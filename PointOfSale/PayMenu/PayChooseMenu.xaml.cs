/*
 * Author: Caden Churchman
 * Class: PayChooseMenu
 * Purpose: Makes the menu to Choose pay type
 */
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

namespace PointOfSale.PayMenu
{
    /// <summary>
    /// Interaction logic for PayChooseMenu.xaml
    /// </summary>
    public partial class PayChooseMenu : UserControl
    {
        /// <summary>
        /// When chosen
        /// </summary>
        public event EventHandler Chosen;

        /// <summary>
        /// The ctor
        /// </summary>
        public PayChooseMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The payment type enum
        /// </summary>
        public enum Payment { Cash, Credit }

        /// <summary>
        /// The credit clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCredit_Click(object sender, RoutedEventArgs e)
        {
            Chosen?.Invoke(Payment.Credit, null);
        }

        /// <summary>
        /// Clicked the thing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCash_Click(object sender, RoutedEventArgs e)
        {
            Chosen?.Invoke(Payment.Cash, null);
        }
    }
}
