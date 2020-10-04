/*
* Author: Caden Churchman
* Class name: Drink.cs
* Purpose: Represents the drinks.
*/
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    public abstract class Drink: IOrderItem
    {
        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public abstract event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Allows properties to be set via string.
        /// </summary>
        /// <param name="property"> the name of the property </param>
        /// <returns> the value of the property </returns>
        /// <exception cref="ArgumentException"> Throws if invalid property name, or invalid property value. </exception>
        public object this[string property]
        {
            get
            {
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
        /// Is the size of the item
        /// </summary>
        public abstract Size Size { get; set; }

        /// <summary>
        /// Gets a string representation of all the boolean properties of a class.
        /// </summary>
        public List<string> BoolOptions
        {
            get
            {
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
        /// Default gets size of drinks.
        /// </summary>
        public virtual Dictionary<string, List<object>> EnumOptions { 
            get {
                var a = new Dictionary<string, List<object>>();
                a.Add("Size", new List<object> { Size.Small, Size.Medium, Size.Large });
                return a;
            }
        }
    }
}
