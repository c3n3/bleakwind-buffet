﻿/*
* Author: Caden Churchman
* Class name: PhillyPoacher.cs
* Purpose: Represents the philly.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Philly sandwaich.
    /// </summary>
    public class PhillyPoacher
    {
        /// <summary>
        /// Gets the sirloin.
        /// </summary>
        public bool Sirloin { get; set; } = true;

        /// <summary>
        /// Gets the onion.
        /// </summary>
        public bool Onion { get; set; } = true;

        /// <summary>
        /// Gets the roll.
        /// </summary>
        public bool Roll { get; set; } = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (!Sirloin) l.Add("Hold sirloin");
                if (!Onion) l.Add("Hold onion");
                if (!Roll) l.Add("Hold roll");
                return l;
            }
        }

        /// <summary>
        /// The price.
        /// </summary>
        public double Price => 7.23;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => 784;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Philly Poacher";
        }
    }
}
