using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /*
     * Author: Caden Churchman
     * Class name: FriedMiraak.cs
     * Purpose: Represents the miraak.
     */
    public class FriedMiraak
    {
        /// <summary>
        /// The size.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// The price.
        /// </summary>
        public double Price => (Size == Size.Small) ? 1.78 : (Size == Size.Medium) ? 2.01 : 2.88;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => (uint)((Size == Size.Small) ? 151 : (Size == Size.Medium) ? 236 : 306);

        /// <summary>
        /// The to string method override.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Fried Miraak";
        }
    }
}
