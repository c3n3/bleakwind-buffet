/*
* Author: Caden Churchman
* Class name: DoubleDraugr.cs
* Purpose: Represents the double burger.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the double draugr menu item.
    /// </summary>
    public class DoubleDraugr : Entree
    {
        public override event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets if bun.
        /// </summary>
        public bool Bun { 
            get
            {
                return _bun;
            }
            set
            {
                _bun = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Bun"));
            }
        }
        private bool _bun = true;

        /// <summary>
        /// Gets if ketchup.
        /// </summary>
        public bool Ketchup { get; set; } 
		private bool _ketchup = true;

        /// <summary>
        /// Gets the mustard.
        /// </summary>
        public bool Mustard { get; set; } 
		private bool _mustard = true;

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
                return l;
            }
        }

        /// <summary>
        /// The price.
        /// </summary>
        public override double Price => 7.32;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 843;

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
