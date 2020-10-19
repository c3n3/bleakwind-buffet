/*
 * Author: Caden Churchman
 * Class: Payment method
 * Purpose: makes the payment methods a bit easier to work with
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.PayMenu
{
    /// <summary>
    /// Makes the payment methods a bit nicer to use
    /// </summary>
    public interface PaymentMethod
    {
        /// <summary>
        /// The remainder price
        /// </summary>
        double Remainder { get; }

        /// <summary>
        /// The type of paymemt
        /// </summary>
        PayChooseMenu.Payment Type { get; }
    }
}
