/*
* Author: Caden Churchman
* Class name: ItemEventArgs.cs
* Purpose: The item event args.
*/
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    /// <summary>
    /// Item event args for when an item needs to be emitted
    /// </summary>
    public class ItemEventArgs : EventArgs
    {
        /// <summary>
        /// item
        /// </summary>
        public IOrderItem item { get; set; }

        /// <summary>
        /// index of the item
        /// </summary>
        public int index;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="i">item</param>
        /// <param name="i2">index</param>
        public ItemEventArgs(IOrderItem i, int i2)
        {
            item = i;
            index = i2;
        }
    }
}
