/*
* Author: Caden Churchman
* Class name: PhillyPoacher.cs
* Purpose: Represents the philly.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents the Philly sandwaich.
    /// </summary>
    public class PhillyPoacher: Entree
    {
		/// <summary>
		/// Description
		/// </summary>
		public override string Description => "Cheesesteak sandwich made from grilled sirloin, topped with onions on a fried roll.";

        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Gets the sirloin.
        /// </summary>
        public bool Sirloin { 
			get 
 			{
				return _sirloin;
			}
			set
			{
				_sirloin = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Sirloin"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _sirloin = true;

        /// <summary>
        /// Gets the onion.
        /// </summary>
        public bool Onion { 
			get 
 			{
				return _onion;
			}
			set
			{
				_onion = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Onion"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _onion = true;

        /// <summary>
        /// Gets the roll.
        /// </summary>
        public bool Roll { 
			get 
 			{
				return _roll;
			}
			set
			{
				_roll = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Roll"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _roll = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (!Sirloin) l.Add("Hold sirloin");
                if (!Onion) l.Add("Hold onions");
                if (!Roll) l.Add("Hold roll");
                return l;
            }
        }

        /// <summary>
        /// The price.
        /// </summary>
        public override double Price => 7.23;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 784;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Philly Poacher";
        }
    }
}
