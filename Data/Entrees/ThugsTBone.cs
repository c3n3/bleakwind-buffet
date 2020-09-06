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
    public class ThugsTBone
    {
        /// <summary>
        /// Gets the instructions.
        /// </summary>
        public List<string> SpecialInstructions => new List<string> { };

        /// <summary>
        /// The pirce.
        /// </summary>
        public double Price => 6.44;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => 982;

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
