/*
* Author: Caden Churchman
* Class name: madOtarGrits.cs
* Purpose: Represents the grits.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represetns the grits.
    /// </summary>
    public class MadOtarGrits: Side
    {
		/// <summary>
		/// Description
		/// </summary>
		public override string Description => "Cheesey Grits.";

        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="size">size</param>
        public MadOtarGrits(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public MadOtarGrits() { }

        /// <summary>
        /// The size.
        /// </summary>
        public override Size Size {
			get => _size;
			set 
			{
				_size = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Size"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Name"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Price"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Calories"));
			}
		} 
		private Size _size = Size.Small;

        /// <summary>
        /// The price.
        /// </summary>
        public override double Price => (Size == Size.Small) ? 1.22 : (Size == Size.Medium) ? 1.58 : 1.93;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 105 : (Size == Size.Medium) ? 142 : 179);

        /// <summary>
        /// Gets the instructions.
        /// </summary>
        public override List<string> SpecialInstructions => new List<string> { };

        /// <summary>
        /// The to string method override.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Mad Otar Grits";
        }
    }
}
