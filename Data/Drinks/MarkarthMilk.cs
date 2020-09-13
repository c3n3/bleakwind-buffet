/*
* Author: Caden Churchman
* Class name: MarkarthMilk.cs
* Purpose: Represents the milk.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents milk
    /// </summary>
    public class MarkarthMilk: Drink
    {
        private bool ice = false;
        private Size size = Size.Small;

        /// <summary>
        /// Markarth milk.
        /// </summary>
        /// <param name="size"> The size. </param>
        public MarkarthMilk(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Default ctor.
        /// </summary>
        public MarkarthMilk() { }

        /// <summary>
        /// Gets if ice.
        /// </summary>
        public bool Ice
        {
            get => ice;
            set => ice = value;
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public override double Price => (Size == Size.Small) ? 1.05 : (Size == Size.Medium) ? 1.11 : 1.22;

        /// <summary>
        /// Gets calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 56 : (Size == Size.Medium) ? 72 : 93);

        /// <summary>
        /// Gets the size.
        /// </summary>
        public override Size Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        /// Gets any special instructions.
        /// </summary>
        public override List<string> SpecialInstructions => Ice ? new List<string> { "Add ice" } : new List<string> { };

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Markarth Milk";
        }
    }
}
