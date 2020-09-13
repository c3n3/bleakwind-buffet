/*
* Author: Caden Churchman
* Class name: Entree.cs
* Purpose: Represents an entree.
*/
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents an entree.
    /// </summary>
    public abstract class Entree : IOrderItem
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
    }
}
