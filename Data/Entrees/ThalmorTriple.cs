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
		/// Property Changed event handler
		/// </summary>
		public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Bun"));
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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Ketchup"));
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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Mustard"));
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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Pickle"));
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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Tomato"));
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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Lettuce"));
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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Mayo"));
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
			}
		} 
		private bool _cheese = true;

        /// <summary>
        /// Get bacon.
        /// </summary>
        public bool Bacon { 
			get 
 			{
				return _bacon;
			}
			set
			{
				_bacon = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Bacon"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
			}
		} 
		private bool _bacon = true;

        /// <summary>
        /// Gets egg.
        /// </summary>
        public bool Egg { 
			get 
 			{
				return _egg;
			}
			set
			{
				_egg = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Egg"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
			}
		} 
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
