using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.MenuTests
{
    public class MenuTests
    {
        [Fact]
        public void DrinksContainOnlyDrinks()
        {
            Assert.Collection(Menu.Drinks(), item => {
                Assert.IsAssignableFrom<Drink>(item);
            });
        }

        [Fact]
        public void EntreesContainOnlyEntrees()
        {
            Assert.Collection(Menu.Entrees(), item =>
            {
                Assert.IsAssignableFrom<Entree>(item);
            });
        }

        [Fact]
        public void SidesShouldContainAllPossibleSizes()
        {
            bool[] assertions = new bool[12];
            Assert.Collection(Menu.Sides(), item =>
            {
                Side side = (Side)item;
                if (side is DragonbornWaffleFries)
                {
                    switch (side.Size)
                    {
                        case Size.Small:
                            assertions[0] = true;
                            break;
                        case Size.Medium:
                            assertions[1] = true;
                            break;
                        case Size.Large:
                            assertions[2] = true;
                            break;
                    }
                }
                if (side is FriedMiraak)
                {
                    switch (side.Size)
                    {
                        case Size.Small:
                            assertions[3] = true;
                            break;
                        case Size.Medium:
                            assertions[4] = true;
                            break;
                        case Size.Large:
                            assertions[5] = true;
                            break;
                    }
                }
                if (side is MadOtarGrits)
                {
                    switch (side.Size)
                    {
                        case Size.Small:
                            assertions[6] = true;
                            break;
                        case Size.Medium:
                            assertions[7] = true;
                            break;
                        case Size.Large:
                            assertions[8] = true;
                            break;
                    }
                }
                if (side is VokunSalad)
                {
                    switch (side.Size)
                    {
                        case Size.Small:
                            assertions[9] = true;
                            break;
                        case Size.Medium:
                            assertions[10] = true;
                            break;
                        case Size.Large:
                            assertions[11] = true;
                            break;
                    }
                }
            });
            Assert.DoesNotContain(false, assertions);
        }

        [Fact]
        public void DrinksContainAllPossibleSizes()
        {
            bool[] assertions = new bool[15];
            Assert.Collection(Menu.Drinks(), item => {
                Drink drink = (Drink)item;
                if (drink is WarriorWater)
                {
                    switch (drink.Size)
                    {
                        case Size.Small:
                            assertions[0] = true;
                            break;
                        case Size.Medium:
                            assertions[1] = true;
                            break;
                        case Size.Large:
                            assertions[2] = true;
                            break;
                    }  
                }
                if (drink is SailorSoda)
                {
                    switch (drink.Size)
                    {
                        case Size.Small:
                            assertions[3] = true;
                            break;
                        case Size.Medium:
                            assertions[4] = true;
                            break;
                        case Size.Large:
                            assertions[5] = true;
                            break;
                    }  
                }
                if (drink is MarkarthMilk)
                {
                    switch (drink.Size)
                    {
                        case Size.Small:
                            assertions[6] = true;
                            break;
                        case Size.Medium:
                            assertions[7] = true;
                            break;
                        case Size.Large:
                            assertions[8] = true;
                            break;
                    }  
                }
                if (drink is CandlehearthCoffee)
                {
                    switch (drink.Size)
                    {
                        case Size.Small:
                            assertions[9] = true;
                            break;
                        case Size.Medium:
                            assertions[10] = true;
                            break;
                        case Size.Large:
                            assertions[11] = true;
                            break;
                    }  
                }
                if (drink is AretinoAppleJuice)
                {
                    switch (drink.Size)
                    {
                        case Size.Small:
                            assertions[12] = true;
                            break;
                        case Size.Medium:
                            assertions[13] = true;
                            break;
                        case Size.Large:
                            assertions[14] = true;
                            break;
                    }  
                }
            });
            Assert.DoesNotContain(false, assertions);
        }
    }
}
