using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Caden Churchman
 * Class name: VokunSalads.cs
 * Purpose: Represents the salad.
 */
namespace BleakwindBuffet.Data.Sides
{
    class VokunSalad
    {
        /// <summary>
        /// The size.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// The price.
        /// </summary>
        public double Price => (Size == Size.Small) ? 0.93 : (Size == Size.Medium) ? 1.28 : 1.82;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => (uint)((Size == Size.Small) ? 41 : (Size == Size.Medium) ? 52 : 73);

        /// <summary>
        /// The to string method override.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Vokun Salad";
        }
    }
}
