using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /*
     * Author: Caden Churchman
     * Class name: DoubleDraugr.cs
     * Purpose: Represents the double burger.
     */
    public class DoubleDraugr
    {
        /// <summary>
        /// Gets if bun.
        /// </summary>
        public bool Bun { get; set; } = true;

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
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Gets if tomato.
        /// </summary>
        public bool Tomato { get; set; } = true;

        /// <summary>
        /// Gets if lettuce.
        /// </summary>
        public bool Lettuce { get; set; } = true;

        /// <summary>
        /// Gets if mayo.
        /// </summary>
        public bool Mayo { get; set; } = true;

        /// <summary>
        /// Gets the cheese.
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public List<string> SpecialInstructions
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
                return l;

            }
        }

        /// <summary>
        /// The price.
        /// </summary>
        public double Price => 7.32;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => 843;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Double Draugr";
        }
    }
}
