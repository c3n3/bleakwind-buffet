/*
* Author: Caden Churchman
* Class name: VokunSalads.cs
* Purpose: Represents the salad.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represents the salad.
    /// </summary>
    public class VokunSalad: Side
    {
		/// <summary>
		/// Description
		/// </summary>
		public override string Description => "A seasonal fruit salad of mellons, berries, mango, grape, apple, and oranges.";

        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="size">size</param>
        public VokunSalad(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// CTOR.
        /// </summary>
        public VokunSalad() { }

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
        public override double Price => (Size == Size.Small) ? 0.93 : (Size == Size.Medium) ? 1.28 : 1.82;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 41 : (Size == Size.Medium) ? 52 : 73);

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
            return $"{Size} Vokun Salad";
        }
    }
}
