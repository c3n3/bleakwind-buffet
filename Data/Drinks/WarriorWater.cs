/*
* Author: Caden Churchman
* Class name: WarriorWater.cs
* Purpose: Represents water.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represents water.
    /// </summary>
    public class WarriorWater: Drink
    {
        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private bool ice = true;
        private bool lemon = false;
        private Size size = Size.Small;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size"> The size </param>
        public WarriorWater(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WarriorWater() { }

        /// <summary>
        /// Whether there is ice.
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
        /// Whether there is a lemon.
        /// </summary>
        public bool Lemon
        {
            get => lemon;
            set 
			{
				lemon = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Lemon"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public override double Price => 0.0;

        /// <summary>
        /// Get calories.
        /// </summary>
        public override uint Calories => 0;

        /// <summary>
        /// Gets special instructions.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (!Ice) l.Add("Hold ice");
                if (Lemon) l.Add("Add lemon");
                return l;
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
			}
        }

        /// <summary>
        /// To string method override.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Size} Warrior Water";
        }
    }
}
