using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Caden Churchman
 * Class name: GardenOmelette.cs
 * Purpose: Represents the omelette.
 */
namespace BleakwindBuffet.Data.Entrees
{
    class GardenOrcOmelette
    {
        /// <summary>
        /// Gets the broc.
        /// </summary>
        public bool Broccoli { get; set; } = true;

        /// <summary>
        /// Gets the mushrooms.
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// Gets the tomato.
        /// </summary>
        public bool Tomato { get; set; } = true;

        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool Cheddar { get; set; } = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public List<string> SpecialInstrucitons
        {
            get
            {
                var l = new List<string> { };
                if (!Mushrooms) l.Add("Hold mushrooms");
                if (!Cheddar) l.Add("Hold cheddar");
                if (!Tomato) l.Add("Hold tomato");
                if (!Broccoli) l.Add("Hold broccoli");
                return l;

            }
        }

        /// <summary>
        /// The pirce.
        /// </summary>
        public double Price => 4.57;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => 404;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Garden Orc Omelette";
        }
    }
}
