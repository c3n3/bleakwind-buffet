/*
* Author: Caden Churchman
* Class name: FriedMiraak.cs
* Purpose: Represents the miraak.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represents the fried miraak.
    /// </summary>
    public class FriedMiraak: Side
    {
        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="size">size</param>
        public FriedMiraak(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public FriedMiraak() { }

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
        public override double Price => (Size == Size.Small) ? 1.78 : (Size == Size.Medium) ? 2.01 : 2.88;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 151 : (Size == Size.Medium) ? 236 : 306);

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
            return $"{Size} Fried Miraak";
        }
    }
}
