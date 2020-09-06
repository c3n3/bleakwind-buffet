/*
* Author: Caden Churchman
* Class name: BriarheartBurger.cs
* Purpose: Represents the burger.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents a burger.
    /// </summary>
    public class BriarheartBurger
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
        /// Gets the mustard
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// Gets the pickle.
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Gets the cheese.
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public List<string> SpecialInstructions {
            get
            {
                var l = new List<string> { };
                if (!Ketchup) l.Add("Hold ketchup");
                if (!Mustard) l.Add("Hold mustard");
                if (!Pickle) l.Add("Hold pickle");
                if (!Bun) l.Add("Hold bun");
                if (!Cheese) l.Add("Hold cheese");
                return l;
            }
        }

        /// <summary>
        /// The price.
        /// </summary>
        public double Price => 6.32;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => 743;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Briarheart Burger";
        }
    }
}
