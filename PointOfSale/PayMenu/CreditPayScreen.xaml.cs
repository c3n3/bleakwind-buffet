/*
 * Author: Caden Churchman
 * Class: CreditPayScreen
 * Purpose: Pay with credit
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
    /// Interaction logic for CreditPayScreen.xaml
    /// </summary>
    public partial class CreditPayScreen : UserControl, PaymentMethod
    {
        /// <summary>
        /// The paid
        /// </summary>
        public event EventHandler Paid;

        /// <summary>
        /// Back
        /// </summary>
        public event EventHandler Back;

        /// <summary>
        /// The cost
        /// </summary>
        private double _cost;

        /// <summary>
        /// Change
        /// </summary>
        public double Remainder => 0; // perfect er time

        public PayChooseMenu.Payment Type => PayChooseMenu.Payment.Credit;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cost"></param>
        public CreditPayScreen(double cost)
        {
            InitializeComponent();
            _cost = cost;
        }

        /// <summary>
        /// This means maybe paid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSwipe_Click(object sender, RoutedEventArgs e)
        {
            var a = RoundRegister.CardReader.RunCard(_cost);
            switch (a)
            {
                case RoundRegister.CardTransactionResult.Approved:
                    Paid?.Invoke(this, null);
                    break;
                case RoundRegister.CardTransactionResult.Declined:
                    {
                        string messageBoxText = "Declined.";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBox.Show(messageBoxText, "", button, icon);
                    }
                    break;
                case RoundRegister.CardTransactionResult.IncorrectPin:
                    {
                        string messageBoxText = "Incorrect Pin.";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBox.Show(messageBoxText, "", button, icon);
                    }
                    break;

                case RoundRegister.CardTransactionResult.InsufficientFunds:
                    {
                        string messageBoxText = "Insuffecient Funds.";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBox.Show(messageBoxText, "", button, icon);

                    }
                    break;
            }
        }

        /// <summary>
        /// The ux back thing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBack_Click(object sender, RoutedEventArgs e)
        {
            Back?.Invoke(this, null);
        }
    }
}
