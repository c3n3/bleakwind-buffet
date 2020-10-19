/*
 * Author: Caden Churchman
 * Class: Represents a stack of one type of money
 * Purpose: Money money monies
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
    /// Interaction logic for Money.xaml
    /// </summary>
    public partial class Money : UserControl
    {
        private Monies.Money _money;

        public Money(Monies.Money money)
        {
            _money = money;
            DataContext = _money;
            InitializeComponent();
        }

        private void uxAdd_Click(object sender, RoutedEventArgs e)
        {
            _money.Count++;
        }

        private void uxSubtract_Click(object sender, RoutedEventArgs e)
        {
            _money.Count--;
        }
    }
}
