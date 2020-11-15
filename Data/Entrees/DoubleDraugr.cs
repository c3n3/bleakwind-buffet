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
		/// <summary>
		/// Description
		/// </summary>
		public override string Description => "Double patty burger on a brioche bun. Comes with ketchup, mustard, pickle, cheese, tomato, lettuce, and mayo.";

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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
            }
        }
        private bool _bun = true;

        /// <summary>
        /// Gets if ketchup.
        /// </summary>
        public bool Ketchup { 
			get 
 			{
				return _ketchup;
			}
			set
			{
				_ketchup = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Ketchup"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _ketchup = true;

        /// <summary>
        /// Gets the mustard.
        /// </summary>
        public bool Mustard { 
			get 
 			{
				return _mustard;
			}
			set
			{
				_mustard = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Mustard"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _mustard = true;

        /// <summary>
        /// Gets the pickle.
        /// </summary>
        public bool Pickle { 
			get 
 			{
				return _pickle;
			}
			set
			{
				_pickle = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Pickle"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _pickle = true;

        /// <summary>
        /// Gets if tomato.
        /// </summary>
        public bool Tomato { 
			get 
 			{
				return _tomato;
			}
			set
			{
				_tomato = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Tomato"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _tomato = true;

        /// <summary>
        /// Gets if lettuce.
        /// </summary>
        public bool Lettuce { 
			get 
 			{
				return _lettuce;
			}
			set
			{
				_lettuce = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Lettuce"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _lettuce = true;

        /// <summary>
        /// Gets if mayo.
        /// </summary>
        public bool Mayo { 
			get 
 			{
				return _mayo;
			}
			set
			{
				_mayo = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Mayo"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _mayo = true;

        /// <summary>
        /// Gets the cheese.
        /// </summary>
        public bool Cheese { 
			get 
 			{
				return _cheese;
			}
			set
			{
				_cheese = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Cheese"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
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
