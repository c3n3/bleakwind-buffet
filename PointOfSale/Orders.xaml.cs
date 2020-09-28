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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        public Orders()
        {
            InitializeComponent();
        }

        public void UpdatePrice()
        {
            double total = 0;
            foreach (var a in uxOrderStack.Children)
            {
                total += ((Item)a).Value.Price;
            }
            uxPrice.Content = $"Price: \n\t{total}";
            Console.WriteLine(total);
        }

        public void AddOrder(IOrderItem item)
        {
            var l = new Item(item.ToString() + $"\n{item.Price}", item);
            l.uxTitle.HorizontalContentAlignment = HorizontalAlignment.Left;
            uxOrderStack.Children.Add(l);
            UpdatePrice();
        }

        private void uxClearOrders_Click(object sender, RoutedEventArgs e)
        {
            uxOrderStack.Children.Clear();
            UpdatePrice();
        }
    }
}
