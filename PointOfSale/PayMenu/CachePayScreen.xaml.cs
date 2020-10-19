/*
 * Author: Caden Churchman
 * Class: CachePayScreen
 * Purpose: Menu for paying with cache
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
    /// Interaction logic for CachePayScreen.xaml
    /// </summary>
    public partial class CachePayScreen : UserControl, PaymentMethod
    {
        public event EventHandler Paid;
        public event EventHandler Back;

        private CacheDrawer _chacheDrawer;

        public double Remainder => _chacheDrawer.Remainder;

        public PayChooseMenu.Payment Type => PayChooseMenu.Payment.Cash;

        public CachePayScreen(double cost)
        {
            InitializeComponent();
            _chacheDrawer = new CacheDrawer(cost);
            DataContext = _chacheDrawer;
            foreach (Monies.Money money in _chacheDrawer.PaymentMonies)
            {
                if (money.IsCoin) {
                    uxCoins.Children.Add(new Money(money));
                }
                else {
                    uxBills.Children.Add(new Money(money));
                }
            }
        }

        private void uxPay_Click(object sender, RoutedEventArgs e)
        {
            _chacheDrawer.Pay();
            Paid?.Invoke(this, null);
        }
    }
}
