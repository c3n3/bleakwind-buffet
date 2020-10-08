/*
* Author: Caden Churchman
* Class name: DragonBornWaffleFries.cs
* Purpose: Represents the fries.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Represents fries.
    /// </summary>
    public class DragonbornWaffleFries: Side
    {
        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="size">size</param>
        public DragonbornWaffleFries(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public DragonbornWaffleFries() { }

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
        public override double Price => (Size == Size.Small) ? 0.42 : (Size == Size.Medium) ? 0.76 : 0.96;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 77 : (Size == Size.Medium) ? 89 : 100);

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
            return $"{Size} Dragonborn Waffle Fries";
        }
    }
}
