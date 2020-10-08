/*
* Author: Caden Churchman
* Class name: Entree.cs
* Purpose: Represents an entree.
*/
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Represents an entree.
    /// </summary>
    public abstract class Entree : IOrderItem
    {
        /// <summary>
        /// This is the property changed
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This is used to bind the to string method
        /// </summary>
        public string Name => ToString();

        /// <summary>
        /// Allows properties to be set via string.
        /// </summary>
        /// <param name="property"> the name of the property </param>
        /// <returns> the value of the property </returns>
        /// <exception cref="ArgumentException"> Throws if invalid property name, or invalid property value. </exception>
        public object this[string property] { 
            get {
                var prop = GetType().GetProperty(property);
                if (prop == null)
                {
                    throw new ArgumentException("Invalid property name.");
                }
                return prop.GetValue(this, null);
            }
            set
            {
                var prop = GetType().GetProperty(property);
                if (prop == null)
                {
                    throw new ArgumentException("Invalid property name.");
                }
                if (prop.PropertyType.Name != value.GetType().Name)
                {
                    throw new ArgumentException($"Invalid type for value. Cannot set {prop.Name} of type {prop.PropertyType.Name} to type {value.GetType().Name}");
                }
                prop.SetValue(this, value, null);                
            }
        }

        /// <summary>
        /// The price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// The special instructions
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }

        /// <summary>
        /// The calories of the item.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Gets a string representation of all the boolean properties of a class.
        /// </summary>
        public List<string> BoolOptions { 
            get {
                List<string> list = new List<string>();
                var props = GetType().GetProperties();

                foreach (var prop in props)
                {
                    if (prop.PropertyType == typeof(bool))
                    {
                        list.Add(prop.Name);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// Default for classes is an empty dictionary.
        /// </summary>
        public virtual Dictionary<string, List<object>> EnumOptions => new Dictionary<string, List<object>>();
    }
}
