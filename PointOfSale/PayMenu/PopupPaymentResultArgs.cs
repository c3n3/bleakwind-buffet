/*
 * Author: Caden Churchman
 * Class: PopupPaymentResultArgs
 * Purpose: Simple args to pass in event
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.PayMenu
{
    /// <summary>
    /// Args for pop up result
    /// </summary>
    public class PopupPaymentResultArgs : EventArgs
    {
        /// <summary>
        /// Type of result
        /// </summary>
        public enum ResultType {CANCEL, CASH_PAYED, CREDIT_PAYED};

        /// <summary>
        /// result
        /// </summary>
        public ResultType result;

        /// <summary>
        /// The payment args
        /// </summary>
        /// <param name="t"></param>
        public PopupPaymentResultArgs(ResultType t)
        {
            result = t;
        }
    }
}
