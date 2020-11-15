/*
* Author: Caden Churchman
* Class name: ThugsTBone.cs
* Purpose: Represents the steak.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represent the tbone steak.
    /// </summary>
    public class ThugsTBone: Entree
    {
		/// <summary>
		/// Description
		/// </summary>
		public override string Description => "Juicy T-Bone, not much else to say.";

        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Gets the instructions.
        /// </summary>
        public override List<string> SpecialInstructions => new List<string> { };

        /// <summary>
        /// The pirce.
        /// </summary>
        public override double Price => 6.44;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 982;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Thugs T-Bone";
        }
    }
}
