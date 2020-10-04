/*
* Author: Caden Churchman
* Class name: CandlehearthCoffee.cs
* Purpose: Represents the coffee.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents the coffee
    /// </summary>
    public class CandlehearthCoffee: Drink
    {
        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Private backing vars.
        /// </summary>
        private bool ice = false;
        private bool decaf = false;
        private bool roomForCream = false;
        private Size size = Size.Small;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="size">size</param>
        public CandlehearthCoffee(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public CandlehearthCoffee() { }

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
			}
        }

        /// <summary>
        /// Gets size.
        /// </summary>
        public override Size Size
        {
            get => size;
            set 
			{
				size = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Size"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Price"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Calories"));
			}
        }

        /// <summary>
        /// Gets if cream.
        /// </summary>
        public bool RoomForCream
        {
            get => roomForCream;
            set 
			{
				roomForCream = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("RoomForCream"));
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Gets if decaf.
        /// </summary>
        public bool Decaf
        {
            get => decaf;
            set 
			{
				decaf = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Decaf"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public override double Price => (Size == Size.Small) ? 0.75 : (Size == Size.Medium) ? 1.25 : 1.75;

        /// <summary>
        /// Gets calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 7 : (Size == Size.Medium) ? 10 : 20);

        /// <summary>
        /// Gets special instructions.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (RoomForCream) l.Add("Add cream");
                if (Ice) l.Add("Add ice");
                return l;
            }
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size}{(Decaf ? " Decaf" : "")} Candlehearth Coffee";
        }
    }
}
