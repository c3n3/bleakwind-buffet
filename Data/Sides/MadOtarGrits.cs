﻿using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /*
     * Author: Caden Churchman
     * Class name: madOtarGrits.cs
     * Purpose: Represents the grits.
     */
    public class MadOtarGrits
    {
        /// <summary>
        /// The size.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// The price.
        /// </summary>
        public double Price => (Size == Size.Small) ? 1.22 : (Size == Size.Medium) ? 1.58 : 1.93;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => (uint)((Size == Size.Small) ? 105 : (Size == Size.Medium) ? 142 : 179);

        /// <summary>
        /// The to string method override.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Mad Otar Grits";
        }
    }
}
