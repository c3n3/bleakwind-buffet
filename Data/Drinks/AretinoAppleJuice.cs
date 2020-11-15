/*
* Author: Caden Churchman
* Class name: AretinoAppleJuice.cs
* Purpose: Represents the juice.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents apple juice
    /// </summary>
    public class AretinoAppleJuice: Drink
    {
        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Private vars
        /// </summary>
        private bool ice = false;
        private Size size = Size.Small;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="size">size</param>
        public AretinoAppleJuice(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public AretinoAppleJuice() { }

        /// <summary>
        /// Gets if ice.
        /// </summary>
        public bool Ice
        {
            get => ice;
            set
            {
                ice = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Ice"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public override Size Size
        {
            get => size;
            set 
			{
				size = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Size"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Name"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Price"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Calories"));
			}
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public override double Price => (Size == Size.Small) ? 0.62 : (Size == Size.Medium) ? 0.87 : 1.01;

        /// <summary>
        /// Gets the calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 44 : (Size == Size.Medium) ? 88 : 132);

        /// <summary>
        /// Gets the special instructions
        /// </summary>
        public override List<string> SpecialInstructions => Ice ? new List<string> { "Add ice" } : new List<string> { };

        /// <summary>
        /// Gets the string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Aretino Apple Juice";
        }

        /// <summary>
        /// This is the description
        /// </summary>
        public override string Description => "Fresh squeezed apple juice.";
    }
}
