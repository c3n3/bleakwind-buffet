using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.MenuTests
{
    public class ComboTests
    {
        [Fact] 
        public void ComboIsIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new Combo());
        }

        [Fact]
        public void ShouldBeConvertableToINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new Combo());
        }

        [Fact]
        public void EnumOptionsShouldBeEmpty()
        {
            Assert.Empty((new Combo()).EnumOptions);
        }

        [Fact]
        public void BoolOptionsShouldBeEmpty()
        {
            Assert.Empty((new Combo()).BoolOptions);
        }

        [Fact]
        public void AddingEntreeShouldNotifyPropertyChange()
        {
            var a = new Combo();
            Assert.PropertyChanged(a, "Entree", () => a.Entree = new BriarheartBurger());
            a = new Combo();
        }

        [Fact]
        public void AddingDrinkShouldNotifyPropertyChange()
        {
            var a = new Combo();
            Assert.PropertyChanged(a, "Drink", () => a.Drink = new SailorSoda());
        }

        [Fact]
        public void AddingSideShouldNotifyPropertyChange()
        {
            var a = new Combo();
            Assert.PropertyChanged(a, "Side", () => a.Side = new DragonbornWaffleFries());
        }

        [Fact]
        public void ChangingEntreeItemShouldChangeSpecialInstructions()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "SpecialInstructions", () => a.Entree = new BriarheartBurger());
        }
        
        [Fact]
        public void ChangingEntreeItemShouldChangePrice()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "Price", () => a.Entree = new BriarheartBurger());
        }
        
        [Fact]
        public void ChangingEntreeItemShouldChangeCalories()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "Calories", () => a.Entree = new BriarheartBurger());
        }

        [Fact]
        public void ChangingDrinkItemShouldChangeSpecialInstructions()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "SpecialInstructions", () => a.Drink = new SailorSoda());
        }
        
        [Fact]
        public void ChangingDrinkItemShouldChangePrice()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "Price", () => a.Drink = new SailorSoda());
        }
        
        [Fact]
        public void ChangingDrinkItemShouldChangeCalories()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "Calories", () => a.Drink = new SailorSoda());
        }

        [Fact]
        public void ChangingSideItemShouldChangeSpecialInstructions()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "SpecialInstructions", () => a.Side = new DragonbornWaffleFries());
        }
        
        [Fact]
        public void ChangingSideItemShouldChangePrice()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "Price", () => a.Side = new DragonbornWaffleFries());
        }
        
        [Fact]
        public void ChangingSideItemShouldChangeCalories()
        {
            Combo a = new Combo();
            Assert.PropertyChanged(a, "Calories", () => a.Side = new DragonbornWaffleFries());
        }

        [Fact]
        public void DrinkEventListenersAreStriped()
        {
            var a = new Combo();
            var b = new SailorSoda();
            a.Drink = b;
            Assert.PropertyChanged(a, "Calories", () => b.Size = Data.Enums.Size.Large);
            a.Drink = new WarriorWater(); 
            try
            {
                Assert.PropertyChanged(a, "Calories", () => b.Size = Data.Enums.Size.Large);
            }
            catch (Xunit.Sdk.PropertyChangedException e) {
                Assert.True(true);
            }
        }

        [Fact]
        public void EntreeEventListenersAreStriped()
        {
            var a = new Combo();
            var b = new BriarheartBurger();
            a.Entree = b;
            Assert.PropertyChanged(a, "SpecialInstructions", () => b.Bun = false);
            a.Entree = new ThugsTBone(); 
            try
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => b.Bun = true);
            }
            catch (Xunit.Sdk.PropertyChangedException e) {
                Assert.True(true);
            }
        }

        [Fact]
        public void SideEventListenersAreStriped()
        {
            var a = new Combo();
            var b = new DragonbornWaffleFries();
            a.Side = b;
            Assert.PropertyChanged(a, "Calories", () => b.Size = Data.Enums.Size.Large);
            a.Entree = new ThugsTBone(); 
            try
            {
                Assert.PropertyChanged(a, "Calories", () => b.Size = Data.Enums.Size.Medium);
            }
            catch (Xunit.Sdk.PropertyChangedException e) {
                Assert.True(true);
            }
        }

        [Fact]
        public void PriceShouldBeAdditionOfAllItemsMinusDiscount()
        {
            Combo a = new Combo();
            var b = new SailorSoda();
            var c = new DragonbornWaffleFries();
            var d = new BriarheartBurger();
            a.Drink = b;
            a.Entree = d;
            a.Side = c;
            Assert.Equal(a.Price, b.Price + c.Price + d.Price - a.Discount);
        }

        [Fact]
        public void CaloriesShouldBeAdditionOfAllItems() 
        {
            Combo a = new Combo();
            var b = new SailorSoda();
            var c = new DragonbornWaffleFries();
            var d = new BriarheartBurger();
            a.Drink = b;
            a.Entree = d;
            a.Side = c;
            Assert.Equal(a.Calories, b.Calories + c.Calories + d.Calories);
        }
        
        [Fact]
        public void SpecialinstructionsShouldBeAdditionOfAllItemsPlusItemNames() 
        {
            Combo a = new Combo();
            var b = new SailorSoda();
            var c = new DragonbornWaffleFries();
            var d = new BriarheartBurger();
            d.Bun = false;
            const int ITEM_COUNT = 3;
            a.Drink = b;
            a.Entree = d;
            a.Side = c;
            Assert.Equal(a.SpecialInstructions.Count, b.SpecialInstructions.Count + c.SpecialInstructions.Count + d.SpecialInstructions.Count + ITEM_COUNT);
        }

        [Fact]
        public void ChangingSubItemShouldNotifyPriceChange()
        {
            Combo a = new Combo();
            var b = new SailorSoda();
            a.Drink = b;
            Assert.PropertyChanged(a, "Price", () => a.Drink.Size = Data.Enums.Size.Large);
        }

        [Fact]
        public void ChangingSubItemShouldNotifyCaloriesChange()
        {
            Combo a = new Combo();
            var b = new SailorSoda();
            a.Drink = b;
            Assert.PropertyChanged(a, "Calories", () => a.Drink.Size = Data.Enums.Size.Large);
        }

        [Fact]
        public void ChangingSubItemShouldNotifySpecialInstructionChange()
        {
            Combo a = new Combo();
            var b = new BriarheartBurger();
            a.Entree = b;
            Assert.PropertyChanged(a, "SpecialInstructions", () => b.Bun = false);
        }

        [Fact]
        public void PropertyGetAndSetShouldThrowNotImplemented()
        {
            Combo a = new Combo();
            Assert.Throws<NotImplementedException>(() => a["fruit"] = false);
            Assert.Throws<NotImplementedException>(() => a["fruit"]);
        }
    }
}
