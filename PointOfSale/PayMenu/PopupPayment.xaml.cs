/*
 * Author: Caden Churchman
 * Class: PopupPayment
 * Purpose: Allows for popup payment windows
 */
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PointOfSale.PayMenu
{
    /// <summary>
    /// Interaction logic for PopupPayment.xaml
    /// </summary>
    public partial class PopupPayment : Page
    {
        /// <summary>
        /// The result
        /// </summary>
        public event EventHandler Result;

        /// <summary>
        /// The cache option
        /// </summary>
        private CachePayScreen _cacheScreen;

        /// <summary>
        /// The credit option
        /// </summary>
        private CreditPayScreen _creditPayScreen;

        private PayChooseMenu _payChooseMenu;

        private Order _order;

        /// <summary>
        /// Setsups a payment
        /// </summary>
        /// <param name="order"> the order </param>
        public PopupPayment(Order order)
        {
            InitializeComponent();
            _order = order;
            DataContext = _order;
            _payChooseMenu = new PayChooseMenu();
            _payChooseMenu.Chosen += PaymentChosen;
            _cacheScreen = new CachePayScreen(order.Total);
            _cacheScreen.Paid += Paid;
            _cacheScreen.Back += Back;
            _creditPayScreen = new CreditPayScreen(order.Total);
            _creditPayScreen.Paid += Paid;
            _creditPayScreen.Back += Back;
            uxContent.Child = _payChooseMenu;
        }

        /// <summary>
        /// Called when thing was chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PaymentChosen(object sender, EventArgs e) 
        {
            if (sender is PayChooseMenu.Payment p)
            {
                switch(p)
                {
                    case PayChooseMenu.Payment.Cash:
                        SetCacheScreen();
                        break;

                    case PayChooseMenu.Payment.Credit:
                        SetCreditScreen();
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the cache screen
        /// </summary>
        public void SetCacheScreen()
        {
            uxContent.Child = _cacheScreen;
        }

        /// <summary>
        /// Sets the pay screen
        /// </summary>
        public void SetPayChooseScreen()
        {
            uxContent.Child = _payChooseMenu;
        }

        /// <summary>
        /// Sets the credit screen
        /// </summary>
        public void SetCreditScreen()
        {
            uxContent.Child = _creditPayScreen;
        }

        /// <summary>
        /// When thing is paid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Paid(object sender, EventArgs e)
        {
            if (sender is CachePayScreen c)
            {
                PrintReceipt(c);
                Result?.Invoke(this, new PopupPaymentResultArgs(PopupPaymentResultArgs.ResultType.CASH_PAYED));

            } else if (sender is CreditPayScreen cd)
            {
                PrintReceipt(cd);
                Result?.Invoke(this, new PopupPaymentResultArgs(PopupPaymentResultArgs.ResultType.CREDIT_PAYED));
            }
        }

        /// <summary>
        /// back to the selet payment type screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Back(object sender, EventArgs e)
        {
            SetPayChooseScreen();
        }

        /// <summary>
        /// Prints out a reciept
        /// </summary>
        /// <param name="payType"></param>
        public void PrintReceipt(PaymentMethod payType)
        {
            RoundRegister.RecieptPrinter.PrintLine("Date: " + DateTime.Now);
            RoundRegister.RecieptPrinter.PrintLine("Order #" + _order.Number);
            RoundRegister.RecieptPrinter.PrintLine("");
            foreach (IOrderItem item in _order)
            {
                Print("\t" + item.Name);
                Print("\tPrice: " + item.Price);
                item.SpecialInstructions.ForEach(ins => Print("\t - " + ins));
                Print("");
            }
            Print("Sales tax rate: " + Math.Round(_order.SalesTaxRate, 2));
            Print("Tax: " + Math.Round(_order.Tax, 2));
            Print("Subtotal: " + Math.Round(_order.Subtotal, 2));
            Print("Total: " + Math.Round(_order.Total, 2));
            Print("Change: " + payType.Remainder);
            Print("Payment method: " + (payType.Type == PayChooseMenu.Payment.Cash ? "cash" : "card"));
            RoundRegister.RecieptPrinter.CutTape();
        }

        /// <summary>
        /// prints while keeping a hard limit at 40 chars
        /// </summary>
        /// <param name="str"></param>
        private void Print(string str)
        {
            if (str.Length > 40)
            {
                List<string> list = new List<string>();
                while (str.Length > 40)
                {
                    list.Add(str.Substring(0, 40));
                    str = str.Substring(40);
                }
                foreach(string s in list)
                {
                    RoundRegister.RecieptPrinter.PrintLine(s);
                }
            } else
            {
                RoundRegister.RecieptPrinter.PrintLine(str);
            }
        }


        /// <summary>
        /// Clicked the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            Result?.Invoke(this, new PopupPaymentResultArgs(PopupPaymentResultArgs.ResultType.CANCEL));
        }
    }
}
