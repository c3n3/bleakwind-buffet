/*
* Author: Caden Churchman
* Class name: ThalmorTriple.cs
* Purpose: Represents the triple burger.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the triple burger.
    /// </summary>
    public class ThalmorTriple: Entree
    {
        /// <summary>
        /// Gets if bun.
        /// </summary>
        public bool Bun { get; set; } 
		private bool _bun = true;

        /// <summary>
        /// Gets if ketchup.
        /// </summary>
        public bool Ketchup { get; set; } = true;

        /// <summary>
        /// Gets the mustard.
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// Gets the pickle.
        /// </summary>
        public bool Pickle { get; set; } 
		private bool _pickle = true;

        /// <summary>
        /// Gets if tomato.
        /// </summary>
        public bool Tomato { get; set; } 
		private bool _tomato = true;

        /// <summary>
        /// Gets if lettuce.
        /// </summary>
        public bool Lettuce { get; set; } 
		private bool _lettuce = true;

        /// <summary>
        /// Gets if mayo.
        /// </summary>
        public bool Mayo { get; set; } 
		private bool _mayo = true;

        /// <summary>
        /// Gets the cheese.
        /// </summary>
        public bool Cheese { get; set; } 
		private bool _cheese = true;

        /// <summary>
        /// Get bacon.
        /// </summary>
        public bool Bacon { get; set; } 
		private bool _bacon = true;

        /// <summary>
        /// Gets egg.
        /// </summary>
        public bool Egg { get; set; } 
		private bool _egg = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (!Ketchup) l.Add("Hold ketchup");
                if (!Bun) l.Add("Hold bun");
                if (!Mustard) l.Add("Hold mustard");
                if (!Pickle) l.Add("Hold pickle");
                if (!Cheese) l.Add("Hold cheese");
                if (!Mayo) l.Add("Hold mayo");
                if (!Tomato) l.Add("Hold tomato");
                if (!Lettuce) l.Add("Hold lettuce");
                if (!Bacon) l.Add("Hold bacon");
                if (!Egg) l.Add("Hold egg");
                return l;

            }
        }

        /// <summary>
        /// The pirce.
        /// </summary>
        public override double Price => 8.32;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 943;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Thalmor Triple";
        }
    }
}
