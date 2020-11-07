/*
 * Author: Caden Churchman
 * Class name: MenuStaticTests.cs
 * Purpose: Tests the static Menu class
 */

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.MenuTests
{
   public class MenuStaticTests
   {
        [Fact]
        public void DrinksContainOnlyDrinks()
        {
            Assert.All(Menu.Drinks(), item => {
                Assert.IsAssignableFrom<Drink>(item);
            });
        }

        [Fact]
        public void EntreesContainOnlyEntrees()
        {
            Assert.All(Menu.Entrees(), item =>
            {
                Assert.IsAssignableFrom<Entree>(item);
            });
        }
        
        [Fact]
        public void SidesContainOnlySides()
        {
            Assert.All(Menu.Sides(), item =>
            {
                Assert.IsAssignableFrom<Side>(item);
            });
        }

        [Fact]
        public void DrinksContainAllInheritedDrinks()
        {
            // Credit to Sam Harwell https://stackoverflow.com/questions/1665120/how-can-i-get-all-the-inherited-classes-of-a-base-class
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Drink)));
            // End Credit
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            foreach (Type t in types)
            {
                assertions.Add(t.FullName, false);
            }
            foreach (IOrderItem item in Menu.Drinks())
            {
                assertions[item.GetType().FullName] = true;
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        }  
        
        [Fact]
        public void DrinkItemsContainAllInheritedDrinks()
        {
            // Credit to Sam Harwell https://stackoverflow.com/questions/1665120/how-can-i-get-all-the-inherited-classes-of-a-base-class
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Drink)));
            // End Credit
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            foreach (Type t in types)
            {
                assertions.Add(t.FullName, false);
            }
            foreach (IOrderItem item in Menu.DrinkItems())
            {
                assertions[item.GetType().FullName] = true;
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        }
        
        [Fact]
        public void EntreesContainAllInheritedEntrees()
        {
            // Credit to Sam Harwell https://stackoverflow.com/questions/1665120/how-can-i-get-all-the-inherited-classes-of-a-base-class
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Entree)));
            // End Credit
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            foreach (Type t in types)
            {
                assertions.Add(t.FullName, false);
            }
            foreach (IOrderItem item in Menu.Entrees())
            {
                assertions[item.GetType().FullName] = true;
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        }
        
        [Fact]
        public void EntreeItemsContainAllInheritedEntrees()
        {
            // Credit to Sam Harwell https://stackoverflow.com/questions/1665120/how-can-i-get-all-the-inherited-classes-of-a-base-class
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Entree)));
            // End Credit
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            foreach (Type t in types)
            {
                assertions.Add(t.FullName, false);
            }
            foreach (IOrderItem item in Menu.EntreeItems())
            {
                assertions[item.GetType().FullName] = true;
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        }
        
        [Fact]
        public void SidesContainAllInheritedSides()
        {
            // Credit to Sam Harwell https://stackoverflow.com/questions/1665120/how-can-i-get-all-the-inherited-classes-of-a-base-class
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Side)));
            // End Credit
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            foreach (Type t in types)
            {
                assertions.Add(t.FullName, false);
            }
            foreach (IOrderItem item in Menu.Sides())
            {
                assertions[item.GetType().FullName] = true;
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        }
        
        [Fact]
        public void SideItemsContainAllInheritedSides()
        {
            // Credit to Sam Harwell https://stackoverflow.com/questions/1665120/how-can-i-get-all-the-inherited-classes-of-a-base-class
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(Side)));
            // End Credit
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            foreach (Type t in types)
            {
                assertions.Add(t.FullName, false);
            }
            foreach (IOrderItem item in Menu.SideItems())
            {
                assertions[item.GetType().FullName] = true;
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        } 

        [Fact]
        public void FullMenuContainsAllIOrderItemsMinusCombos()
        {
            // Credit to Sam Harwell https://stackoverflow.com/questions/1665120/how-can-i-get-all-the-inherited-classes-of-a-base-class
            var types = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => typeof(IOrderItem).IsAssignableFrom(type));
            // End Credit
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            foreach (Type t in types)
            {
                if (t.IsAbstract) // no checking abstract classes since they cannot be implemented
                {
                    continue;
                }
                if (t.Name == typeof(Combo).Name) // Exception for a combo as this varies
                {
                    continue;
                }
                assertions.Add(t.FullName, false);
            }
            foreach (IOrderItem item in Menu.FullMenu())
            {
                assertions[item.GetType().FullName] = true;
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        }

        [Fact]
        public void AllPossibleSailorSodasAreInDrinks()
        {
            SodaFlavor[] flavors = (SodaFlavor[])Enum.GetValues(typeof(SodaFlavor));
            Size[] sizes = (Size[])Enum.GetValues(typeof(Size));
            Dictionary<SodaFlavor, List<Size>> assertions = new Dictionary<SodaFlavor, List<Size>>();
            foreach (SodaFlavor f in flavors) 
            {
                assertions.Add(f, new List<Size>());
            }
            foreach (IOrderItem item in Menu.Drinks())
            {
                if (item is SailorSoda)
                {
                    SailorSoda s = (SailorSoda)item;
                    if (!assertions[s.Flavor].Contains(s.Size))
                    {
                        assertions[s.Flavor].Add(s.Size);
                    }
                }
            }
            Assert.All(assertions, item => Assert.Equal(item.Value.Count, sizes.Length));
        }

        [Fact]
        public void SidesShouldContainAllPossibleSizes()
        {
            Size[] sizes = (Size[])Enum.GetValues(typeof(Size));
            Dictionary<string, List<Size>> assertions = new Dictionary<string, List<Size>>();
            assertions.Add(typeof(DragonbornWaffleFries).Name, new List<Size>());
            assertions.Add(typeof(FriedMiraak).Name, new List<Size>());
            assertions.Add(typeof(MadOtarGrits).Name, new List<Size>());
            assertions.Add(typeof(VokunSalad).Name, new List<Size>());
            foreach (IOrderItem item in Menu.Sides()) 
            { 
                Side side = (Side)item;
                if (!assertions[side.GetType().Name].Contains(side.Size))
                {
                    assertions[side.GetType().Name].Add(side.Size);
                }
            }
            Assert.All(assertions, item => Assert.Equal(item.Value.Count, sizes.Length));
        }
        
        [Fact]
        public void SidesItemsShouldContainAllSides()
        {
            Size[] sizes = (Size[])Enum.GetValues(typeof(Size));
            Dictionary<string, bool> assertions = new Dictionary<string, bool>();
            assertions.Add(typeof(DragonbornWaffleFries).Name, false);
            assertions.Add(typeof(FriedMiraak).Name, false);
            assertions.Add(typeof(MadOtarGrits).Name, false);
            assertions.Add(typeof(VokunSalad).Name, false);
            foreach (IOrderItem item in Menu.SideItems()) 
            { 
                Side side = (Side)item;
                if (!assertions[side.GetType().Name])
                {
                    assertions[side.GetType().Name] = true;
                }
            }
            Assert.All(assertions, item => Assert.True(item.Value));
        }

        [Fact]
        public void SidesItemsShouldNotifyNameForEnumOptions()
        {
            foreach (IOrderItem item in Menu.SideItems())
            {
                foreach (var kv in item.EnumOptions)
                {
                    Assert.PropertyChanged(item, kv.Key, () => item[kv.Key] = kv.Value[kv.Value.Count - 1]);
                }
            }
        }

        [Fact]
        public void DrinksContainAllPossibleSizes()
        {
            Size[] sizes = (Size[])Enum.GetValues(typeof(Size));
            Dictionary<string, List<Size>> assertions = new Dictionary<string, List<Size>>();
            assertions.Add(typeof(AretinoAppleJuice).Name, new List<Size>());
            assertions.Add(typeof(CandlehearthCoffee).Name, new List<Size>());
            assertions.Add(typeof(MarkarthMilk).Name, new List<Size>());
            assertions.Add(typeof(SailorSoda).Name, new List<Size>());
            assertions.Add(typeof(WarriorWater).Name, new List<Size>());
            foreach (IOrderItem item in Menu.Drinks())
            { 
                Drink side = (Drink)item;
                if (!assertions[side.GetType().Name].Contains(side.Size))
                {
                    assertions[side.GetType().Name].Add(side.Size);
                }
            }
            Assert.All(assertions, item => Assert.Equal(item.Value.Count, sizes.Length));
        }

        [Fact]
        public void FilterFunctionFilters()
        {
            var a = Menu.FullMenu().ToList();
            Menu.Filter(ref a, x => x.Calories == 0);
            foreach (var b in a)
            {
                Assert.Equal((uint)0, b.Calories);
            }
        }

        [Fact]
        public void FilterFunctionFiltersPart2()
        {
            var a = Menu.FullMenu().ToList();
            Menu.Filter(ref a, x => x.Price < 1);
            foreach (var b in a)
            {
                Assert.True(b.Price < 1);
            }
        }
    }
}
