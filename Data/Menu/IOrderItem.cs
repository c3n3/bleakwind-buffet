/*
* Author: Caden Churchman
* Class name: IOrderItem.cs
* Purpose: represents an order item.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Menu
{
    /// <summary>
    /// This represents an order item.
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// The price of the item.
        /// </summary>
        double Price { get; }

        /// <summary>
        /// This is the property for the special instructions for preperation.
        /// </summary>
        List<string> SpecialInstructions { get; }

        /// <summary>
        /// Represents the calories
        /// </summary>
        uint Calories { get; }
    }
}
