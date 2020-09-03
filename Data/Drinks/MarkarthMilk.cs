using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Caden Churchman
 * Class name: MarkarthMilk.cs
 * Purpose: Represents the milk.
 */
namespace BleakwindBuffet.Data.Drinks
{
    public class MarkarthMilk
    {
        private bool ice = true;
        private Size size = Size.Small;

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
        public double Price => (Size == Size.Small) ? 1.05 : (Size == Size.Medium) ? 1.11 : 1.22;

        /// <summary>
        /// Gets calories.
        /// </summary>
        public uint Calories => (uint)((Size == Size.Small) ? 56 : (Size == Size.Medium) ? 72 : 93);

        /// <summary>
        /// Gets the size.
        /// </summary>
        public Size Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        /// Gets any special instructions.
        /// </summary>
        public List<string> SpecialInstructions => Ice ? new List<string> { "Add ice" } : new List<string> { };

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
