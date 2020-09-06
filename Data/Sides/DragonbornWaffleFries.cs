/*
* Author: Caden Churchman
* Class name: DragonBornWaffleFries.cs
* Purpose: Represents the fries.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represents fries.
    /// </summary>
    public class DragonbornWaffleFries
    {
        /// <summary>
        /// The size.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// The price.
        /// </summary>
        public double Price => (Size == Size.Small) ? 0.42 : (Size == Size.Medium) ? 0.76 : 0.96;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => (uint)((Size == Size.Small) ? 77 : (Size == Size.Medium) ? 89 : 100);

        /// <summary>
        /// The to string method override.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Dragonborn Waffle Fries";
        }
    }
}
