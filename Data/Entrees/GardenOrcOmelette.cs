/*
* Author: Caden Churchman
* Class name: GardenOmelette.cs
* Purpose: Represents the omelette.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the garden omelette.
    /// </summary>
    public class GardenOrcOmelette: Entree
    {
        /// <summary>
        /// Gets the broc.
        /// </summary>
        public bool Broccoli { get; set; } 
		private bool _broccoli = true;

        /// <summary>
        /// Gets the mushrooms.
        /// </summary>
        public bool Mushrooms { get; set; } 
		private bool _mushrooms = true;

        /// <summary>
        /// Gets the tomato.
        /// </summary>
        public bool Tomato { get; set; } 
		private bool _tomato = true;

        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool Cheddar { get; set; } 
		private bool _cheddar = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public override List<string> SpecialInstructions
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
        public override double Price => 4.57;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 404;

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
