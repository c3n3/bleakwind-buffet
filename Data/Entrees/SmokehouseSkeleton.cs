/*
* Author: Caden Churchman
* Class name: SmokehouseSkeleton.cs
* Purpose: Represents the breakfast item.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{   
    /// <summary>
    /// Represents the smokehouse skeleton.
    /// </summary>
    public class SmokehouseSkeleton: Entree
    {
        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool SausageLink { get; set; } = true;
        
        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool Egg { get; set; } = true;
        
        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool HashBrowns{ get; set; } = true;
        
        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool Pancake{ get; set; } = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (!Egg) l.Add("Hold eggs");
                if (!HashBrowns) l.Add("Hold hash browns");
                if (!Pancake) l.Add("Hold pancakes");
                if (!SausageLink) l.Add("Hold sausage");
                return l;

            }
        }

        /// <summary>
        /// The pirce.
        /// </summary>
        public override double Price => 5.62;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 602;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }
    }
}
