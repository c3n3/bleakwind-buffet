/*
* Author: Caden Churchman
* Class name: SailorSoda.cs
* Purpose: Represents the soda.
*/
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Represent soda of many flavors
    /// </summary>
    public class SailorSoda : Drink
    {
        /// <summary>
        /// This is the description
        /// </summary>
        public override string Description => "An old-fashioned jerked soda, carbonated water and flavored syrup poured over a bed of crushed ice.";

        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private bool ice = true;
        private SodaFlavor flavor = SodaFlavor.Cherry;
        private Size size = Size.Small;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size"> The size of the thing </param>
        /// <param name="flavor"> the flavor </param>
        public SailorSoda(Size size, SodaFlavor flavor)
        {
            Size = size;
            Flavor = flavor;
        }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SailorSoda() { }

        /// <summary>
        /// Gets if there is ice.
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
        /// Gets the flavor.
        /// </summary>
        public SodaFlavor Flavor
        {
            get => flavor;
            set 
			{
				flavor = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Flavor"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Name"));
			}
        }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public override double Price => (Size == Size.Small) ? 1.42 : (Size == Size.Medium) ? 1.74 : 2.07;

        /// <summary>
        /// Gets the calories.
        /// </summary>
        public override uint Calories => (uint)((Size == Size.Small) ? 117 : (Size == Size.Medium) ? 153 : 205);

        /// <summary>
        /// Gets special instructions.
        /// </summary>
        public override List<string> SpecialInstructions => (!Ice) ? new List<string> { "Hold ice" } : new List<string> { };

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
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Name"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Price"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Calories"));
			}
        }

        /// <summary>
        /// Overrides the to string method.
        /// </summary>
        /// <returns> The string. </returns>
        public override string ToString()
        {
            return $"{Size} {Flavor} Sailor Soda";
        }

        /// <summary>
        /// Have to add soda flavors to the options.
        /// </summary>
        public override Dictionary<string, List<object>> EnumOptions
        {
            get
            {
                var a = base.EnumOptions;
                a.Add("Flavor", new List<object> { SodaFlavor.Blackberry, SodaFlavor.Cherry, SodaFlavor.Grapefruit, SodaFlavor.Lemon, SodaFlavor.Peach, SodaFlavor.Watermelon });
                return a;
            }
        }
    }
}
