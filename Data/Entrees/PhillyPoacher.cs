using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Caden Churchman
 * Class name: PhillyPoacher.cs
 * Purpose: Represents the philly.
 */
namespace BleakwindBuffet.Data.Entrees
{
    class PhillyPoacher
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
        public List<string> SpecialInstrucitons
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
        public double Price => 5.62;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => 602;

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
