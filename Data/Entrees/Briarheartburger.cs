/*
* Author: Caden Churchman
* Class name: BriarheartBurger.cs
* Purpose: Represents the burger.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents a burger.
    /// </summary>
    public class BriarheartBurger : Entree
    {
        public override event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets if bun.
        /// </summary>
        public bool Bun
        {
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
        public bool Ketchup 
        { 
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
        /// Gets the mustard
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
        public override List<string> SpecialInstructions {
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
        public override double Price => 6.32;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 743;

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
