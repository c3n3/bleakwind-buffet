using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Author: Caden Churchman
 * Class name: WarriorWater.cs
 * Purpose: Represents water.
 */
namespace BleakwindBuffet.Data.Drinks
{
    public class WarriorWater
    {
        private bool ice = true;
        private bool lemon = false;
        private Size size = Size.Small;

        /// <summary>
        /// Whether there is ice.
        /// </summary>
        public bool Ice
        {
            get => ice;
            set => ice = value;
        }

        /// <summary>
        /// Whether there is a lemon.
        /// </summary>
        public bool Lemon
        {
            get => lemon;
            set => lemon = value;
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public double Price => 0.0;

        /// <summary>
        /// Get calories.
        /// </summary>
        public uint Calories => 0;

        /// <summary>
        /// Gets special instructions.
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (Ice) l.Add("Add ice");
                if (Lemon) l.Add("Add lemon");
                return l;
            }
        }

        /// <summary>
        /// Gets size.
        /// </summary>
        public Size Size
        {
            get => size;
            set => size = value;
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
