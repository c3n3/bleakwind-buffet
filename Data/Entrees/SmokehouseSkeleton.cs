using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /*
     * Author: Caden Churchman
     * Class name: SmokehouseSkeleton.cs
     * Purpose: Represents the breakfast item.
     */
    public class SmokehouseSkeleton
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
        public List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (!Egg) l.Add("Hold egg");
                if (!HashBrowns) l.Add("Hold hash browns");
                if (!Pancake) l.Add("Hold pancake");
                if (!SausageLink) l.Add("Hold sausage");
                return l;

            }
        }

        /// <summary>
        /// The pirce.
        /// </summary>
        public double Price => 5.62;

        /// <summary>
        /// The calories.
        /// </summary>
        public uint Calories => 602;

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
