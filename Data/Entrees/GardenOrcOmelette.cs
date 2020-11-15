/*
* Author: Caden Churchman
* Class name: GardenOmelette.cs
* Purpose: Represents the omelette.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the garden omelette.
    /// </summary>
    public class GardenOrcOmelette: Entree
    {
		/// <summary>
		/// Description
		/// </summary>
		public override string Description => "Vegetarian. Two egg omelette packed with a mix of broccoli, mushrooms, and tomatoes. Topped with cheddar cheese.";

        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the broc.
        /// </summary>
        public bool Broccoli { 
			get 
 			{
				return _broccoli;
			}
			set
			{
				_broccoli = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Broccoli"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _broccoli = true;

        /// <summary>
        /// Gets the mushrooms.
        /// </summary>
        public bool Mushrooms { 
			get 
 			{
				return _mushrooms;
			}
			set
			{
				_mushrooms = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Mushrooms"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _mushrooms = true;

        /// <summary>
        /// Gets the tomato.
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
        /// Gets the link.
        /// </summary>
        public bool Cheddar { 
			get 
 			{
				return _cheddar;
			}
			set
			{
				_cheddar = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Cheddar"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
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
