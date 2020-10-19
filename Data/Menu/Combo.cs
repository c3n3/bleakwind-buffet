/*
* Author: Caden Churchman
* Class name: Combo.cs
* Purpose: The combo item on the menu.
*/
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BleakwindBuffet.Data.Menu
{
    /// <summary>
    /// Represents a combo order
    /// </summary>
    public class Combo : IOrderItem
    {
        /// <summary>
        /// This is used to bind the to string method
        /// </summary>
        public string Name => "Combo";

        /// <summary>
        /// The event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Discount applied at total price
        /// </summary>
        public double Discount => 1;

        /// <summary>
        /// The Drink in the combo
        /// </summary>
        public Drink Drink { 
            get
            {
                return _drink;
            } 
            set
            {
                Calories = Calories - (Drink == null ? 0 : Drink.Calories) + value.Calories;
                Price = _price - (Drink == null ? 0 : Drink.Price) + value.Price;
                if (_drink != null)
                {
                    _drink.PropertyChanged -= ItemChangedEventListener;
                }
                _drink = value;
                _drink.PropertyChanged += ItemChangedEventListener;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Drink"));
            }
        }
        private Drink _drink;

        /// <summary>
        /// The entree
        /// </summary>
        public Entree Entree
        {
            get
            {
                return _entree;
            }
            set
            {
                Calories = Calories + (Entree == null ? 0 : Entree.Calories) + value.Calories;
                Price = _price - (Entree == null ? 0 : Entree.Price) + value.Price;
                if (_entree != null)
                {
                    _entree.PropertyChanged -= ItemChangedEventListener;
                }
                _entree = value;
                _entree.PropertyChanged += ItemChangedEventListener;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entree"));
            }
        }
        private Entree _entree;

        /// <summary>
        /// The side
        /// </summary>
        public Side Side
        {
            get
            {
                return _side;
            }
            set
            {
                Calories = Calories - (Side == null ? 0 : Side.Calories) + value.Calories;
                Price = _price - (Side == null ? 0 : Side.Price) + value.Price;
                if (_side != null)
                {
                    _side.PropertyChanged -= ItemChangedEventListener;
                }
                _side = value;
                _side.PropertyChanged += ItemChangedEventListener;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Side"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }
        private Side _side;

        /// <summary>
        /// Gets a list of all the items
        /// </summary>
        public List<IOrderItem> Items
        {
            get
            {
                var a = new List<IOrderItem>();
                if (Side != null)
                {
                    a.Add(Side);
                }
                if (Entree != null)
                {
                    a.Add(Entree);
                }
                if (Drink != null)
                {
                    a.Add(Drink);
                }
                return a;
            }
        }
        
        /// <summary>
        /// Calories
        /// </summary>
        public uint Calories 
        { 
            get 
            {
                return _calories;
            } 
            private set
            {
                if (_calories == value) return;
                _calories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }
        private uint _calories = 0;

        /// <summary>
        /// Price
        /// </summary>
        public double Price
        {
            get
            {
                return  _price - Discount;
            }
            private set
            {
                if (_price == value) return;
                _price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }
        private double _price = 0;

        /// <summary>
        /// Curently no bool options for a combo
        /// </summary>
        public List<string> BoolOptions
        {
            get
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Currently no enum options for a combo.
        /// </summary>
        public Dictionary<string, List<object>> EnumOptions
        {
            get
            {
                return new Dictionary<string, List<object>>();
            }
        }
            
        /// <summary>
        /// Special instructions
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                var a = new List<string>();
                foreach (var item in Items)
                {
                    a.Add(item.ToString() + ":");
                    foreach (var str in item.SpecialInstructions)
                    {
                        a.Add(str);
                    }
                }
                return a;
            }
        }

        /// <summary>
        /// listens for property changes in items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ItemChangedEventListener(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IOrderItem item)
            {
                if (e.PropertyName == "Price")
                {
                    Price = (Entree == null ? 0 : Entree.Price) + (Side == null ? 0 : Side.Price) + (Drink == null ? 0 : Drink.Price);
                }
                else if (e.PropertyName == "Calories")
                {
                    Calories = (Entree == null ? 0 : Entree.Calories) + (Side == null ? 0 : Side.Calories) + (Drink == null ? 0 : Drink.Calories);
                }
                else if (e.PropertyName == "SpecialInstructions")
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Should not be used for this class as of right now. EnumOptions and BoolOptions will return nothing therfore nothing is valid to use this with
        /// </summary>
        /// <param name="property"> This is the property </param>
        /// <returns> The value </returns>
        public object this[string property] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
