/*
* Author: Caden Churchman
* Class name: Side.cs
* Purpose: represents sides.
*/
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represents a generic side.
    /// </summary>
    public abstract class Side: IOrderItem
    {
        /// <summary>
        /// The price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// The special instructions
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }

        /// <summary>
        /// The calories of the item.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The size of the item
        /// </summary>
        public abstract Size Size { get; set; }
    }
}
