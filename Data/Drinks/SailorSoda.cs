using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace BleakwindBuffet.Data.Drinks
{
    /*
     * Author: Caden Churchman
     * Class name: SailorSoda.cs
     * Purpose: Represents the soda.
     */
    public class SailorSoda
    {
        private bool ice = true;
        private SodaFlavor flavor = SodaFlavor.Cherry;
        private Size size = Size.Small;

        /// <summary>
        /// Gets if there is ice.
        /// </summary>
        public bool Ice
        {
            get => ice;
            set => ice = value;
        }

        /// <summary>
        /// Gets the flavor.
        /// </summary>
        public SodaFlavor Flavor
        {
            get => flavor;
            set => flavor = value;
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public double Price => (Size == Size.Small) ? 1.42 : (Size == Size.Medium) ? 1.74 : 2.07;

        /// <summary>
        /// Gets the calories.
        /// </summary>
        public uint Calories => (uint)((Size == Size.Small) ? 117 : (Size == Size.Medium) ? 153 : 205);

        /// <summary>
        /// Gets special instructions.
        /// </summary>
        public List<string> SpecialInstructions => (!Ice) ? new List<string> {"Hold ice"} : new List<string> { };

        /// <summary>
        /// Gets size.
        /// </summary>
        public Size Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        /// Overrides the to string method.
        /// </summary>
        /// <returns> The string. </returns>
        public override string ToString()
        {
            return $"{Size} {Flavor} Sailor Soda";
        }
    }
}
