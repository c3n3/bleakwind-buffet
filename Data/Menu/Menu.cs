/*
* Author: Caden Churchman
* Class name: Menu.cs
* Purpose: Repersents the menu.
*/
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Menu
{
    public static class Menu
    {
        /// <summary>
        /// Gets all the sides.
        /// </summary>
        /// <returns>Array of the objects.</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            return new List<IOrderItem> { 
                new DragonbornWaffleFries(Size.Small), new FriedMiraak(Size.Small), new MadOtarGrits(Size.Small), new VokunSalad(Size.Small),
                new DragonbornWaffleFries(Size.Medium), new FriedMiraak(Size.Medium), new MadOtarGrits(Size.Medium), new VokunSalad(Size.Medium),
                new DragonbornWaffleFries(Size.Large), new FriedMiraak(Size.Large), new MadOtarGrits(Size.Large), new VokunSalad(Size.Large),
            };
        }
        
        /// <summary>
        /// An array of entrees.
        /// </summary>
        /// <returns> The array </returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            return new List<IOrderItem> { new BriarheartBurger(), new DoubleDraugr(), new GardenOrcOmelette(), new PhillyPoacher(), new SmokehouseSkeleton(), new ThalmorTriple(), new ThugsTBone() };
        }

        /// <summary>
        /// An array of the drinks.
        /// </summary>
        /// <returns> the array </returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            var temp = new List<IOrderItem> {
                new AretinoAppleJuice(Size.Small), new CandlehearthCoffee(Size.Small), new MarkarthMilk(Size.Small), new WarriorWater(Size.Small),
                new AretinoAppleJuice(Size.Medium), new CandlehearthCoffee(Size.Medium), new MarkarthMilk(Size.Medium), new WarriorWater(Size.Medium),
                new AretinoAppleJuice(Size.Large), new CandlehearthCoffee(Size.Large), new MarkarthMilk(Size.Large), new WarriorWater(Size.Large),
            };
            foreach (Size s in Enum.GetValues(typeof(Size)))
            {
                foreach (SodaFlavor f in Enum.GetValues(typeof(SodaFlavor)))
                {
                    temp.Add(new SailorSoda(s, f));
                }
            }
            return temp;
        }

        /// <summary>
        /// This grabs everything on the menu
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> FullMenu()
        {

            List<IOrderItem> temp = new List<IOrderItem>();
            foreach (IOrderItem item in Drinks())
            {
                temp.Add(item);
            }
            foreach (IOrderItem item in Sides())
            {
                temp.Add(item);
            }
            foreach (IOrderItem item in Entrees())
            {
                temp.Add(item);
            }
            return temp;
        }
    }
}
