using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Caden Churchman
 * Class name: AretinoAppleJuice.cs
 * Purpose: Represents the juice.
 */
namespace BleakwindBuffet.Data.Drinks
{
    class AretinoAppleJuice
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
        /// Gets the size.
        /// </summary>
        public Size Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public double Price => (Size == Size.Small) ? 0.62 : (Size == Size.Medium) ? 0.87 : 1.01;

        /// <summary>
        /// Gets the calories.
        /// </summary>
        public uint Calories => (uint)((Size == Size.Small) ? 44 : (Size == Size.Medium) ? 88 : 132);

        /// <summary>
        /// Gets the special instructions
        /// </summary>
        public List<string> SpecialInstructions => Ice ? new List<string> { "Add ice" } : new List<string> { };

        /// <summary>
        /// Gets the string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Aretino Apple Juice";
        }
    }
}
