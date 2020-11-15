/*
* Author: Caden Churchman
* Class name: IOrderItem.cs
* Purpose: represents an order item.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Menu
{
    /// <summary>
    /// This represents an order item.
    /// </summary>
    public interface IOrderItem : INotifyPropertyChanged
    {
        /// <summary>
        /// This is used to bind the to string method
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The price of the item.
        /// </summary>
        double Price { get; }

        /// <summary>
        /// Allows properties to be set via string.
        /// </summary>
        /// <param name="property"> the name of the property </param>
        /// <returns> the value of the property </returns>
        /// <exception cref="ArgumentException"> Throws if invalid property name, or invalid property value. </exception>
        object this[string property] { get; set; }

        /// <summary>
        /// All the boolean options for an item.
        /// </summary>
        List<string> BoolOptions { get; }

        /// <summary>
        /// All the enum options for an item. This has to be represented as a dictionary keyed by property with an object list to hold options. A possible solution would be to create a 
        /// generic ListOptions class to avoid dynamic typing, but then I would be killing the first part of the assignment. Dynamic typing it is!
        /// </summary>
        Dictionary<string, List<object>> EnumOptions { get; }

        /// <summary>
        /// This is the property for the special instructions for preperation.
        /// </summary>
        List<string> SpecialInstructions { get; }

        /// <summary>
        /// Represents the calories
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// This is a description
        /// </summary>
        string Description { get; }
    }
}
