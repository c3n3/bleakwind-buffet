/*
* Author: Caden Churchman
* Class name: Drink.cs
* Purpose: Represents the drinks.
*/
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    public abstract class Drink: IOrderItem
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
        /// Is the size of the item
        /// </summary>
        public abstract Size Size { get; set; }
    }
}
