﻿using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Caden Churchman
 * Class name: CandlehearthCoffee.cs
 * Purpose: Represents the coffee.
 */
namespace BleakwindBuffet.Data.Drinks
{
    class CandlehearthCoffee
    {
        private bool ice = true;
        private bool decaf = false;
        private bool roomForCream = false;
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
        /// Gets size.
        /// </summary>
        public Size Size
        {
            get => size;
            set => size = value;
        }

        /// <summary>
        /// Gets if cream.
        /// </summary>
        public bool RoomForCream
        {
            get => roomForCream;
            set => roomForCream = value;
        }

        /// <summary>
        /// Gets if decaf.
        /// </summary>
        public bool Decaf
        {
            get => decaf;
            set => decaf = value;
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public double Price => (Size == Size.Small) ? 0.75 : (Size == Size.Medium) ? 1.25 : 1.75;

        /// <summary>
        /// Gets calories.
        /// </summary>
        public double Calories => (Size == Size.Small) ? 7 : (Size == Size.Medium) ? 10 : 20;

        /// <summary>
        /// Gets special instructions.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (RoomForCream) l.Add("Add Cream");
                if (Ice) l.Add("Add Ice");
                return l;
            }
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Candlehearth Coffee";
        }
    }
}
