/*
 * Author: Zachery Brunner
*Edited By Caden Churchman
 * Class: CandlehearthCoffeeTests.cs
 * Purpose: Test the CandlehearthCoffee.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using BleakwindBuffet.Data.Menu;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
   public class CandlehearthCoffeeTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new CandlehearthCoffee());
		}

        [Fact]
        public void AllBooleanPropertiesShouldNotifyOfChange()
        {
            CandlehearthCoffee a = new CandlehearthCoffee();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, option, () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new CandlehearthCoffee();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void AllBoolOptionsShouldChangeSpecialInstructions()
        {
            CandlehearthCoffee a = new CandlehearthCoffee();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void SizeShouldChangePrice()
        {
            var a = new CandlehearthCoffee();
            Assert.PropertyChanged(a, "Price", () => a.Size = Size.Large);
        }

        [Fact]
        public void SizeShouldChangeCalories()
        {
            var a = new CandlehearthCoffee();
            Assert.PropertyChanged(a, "Calories", () => a.Size = Size.Large);
        }

        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
            var a = new CandlehearthCoffee();
            Assert.False(a.Ice);
        }

        [Fact]
        public void ShouldNotBeDecafByDefault()
        {
            var a = new CandlehearthCoffee();
            Assert.False(a.Decaf);
        }

        [Fact]
        public void ShouldNotHaveRoomForCreamByDefault()
        {
            var a = new CandlehearthCoffee();
            Assert.False(a.RoomForCream);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var c = new CandlehearthCoffee();
            Assert.Equal(Size.Small, c.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var a = new CandlehearthCoffee();
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetDecaf()
        {
            foreach (BleakwindBuffet.Data.Menu.IOrderItem item in BleakwindBuffet.Data.Menu.Menu.Drinks())
            {
                int test = 0;
            }
            var a = new CandlehearthCoffee();
            a.Decaf = true;
            Assert.True(a.Decaf);
        }

        [Fact]
        public void ShouldBeAbleToSetRoomForCream()
        {
            var a = new CandlehearthCoffee();
            a.RoomForCream = true;
            Assert.True(a.RoomForCream);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new CandlehearthCoffee();
            a.Size = Size.Large;
            Assert.Equal(Size.Large, a.Size);
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
        }

        [Theory]
        [InlineData(Size.Small, 0.75)]
        [InlineData(Size.Medium, 1.25)]
        [InlineData(Size.Large, 1.75)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var a = new CandlehearthCoffee();
            a.Size = size;
            Assert.Equal(price, a.Price);
        }

        [Theory]
        [InlineData(Size.Small, 7)]
        [InlineData(Size.Medium, 10)]
        [InlineData(Size.Large, 20)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var a = new CandlehearthCoffee();
            a.Size = size;
            Assert.Equal(cal, a.Calories);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeCream)
        {
            var a = new CandlehearthCoffee();
            a.Ice = includeIce;
            a.RoomForCream = includeCream;
            if (includeCream)
            {
                Assert.Contains("Add cream", a.SpecialInstructions);
            } else
            {
                Assert.DoesNotContain("Add cream", a.SpecialInstructions);
            }
            if (includeIce)
            {
                Assert.Contains("Add ice", a.SpecialInstructions);
            } else
            {
                Assert.DoesNotContain("Add ice", a.SpecialInstructions);
            }
        }

        [Theory]
        [InlineData(true, Size.Small, "Small Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Medium, "Medium Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Large, "Large Decaf Candlehearth Coffee")]
        [InlineData(false, Size.Small, "Small Candlehearth Coffee")]
        [InlineData(false, Size.Medium, "Medium Candlehearth Coffee")]
        [InlineData(false, Size.Large, "Large Candlehearth Coffee")]
        public void ShouldReturnCorrectToStringBasedOnSize(bool decaf, Size size, string name)
        {
            var a = new CandlehearthCoffee();
            a.Decaf = decaf;
            a.Size = size;
            Assert.Equal(name, a.ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new CandlehearthCoffee();
            Assert.IsAssignableFrom<Drink>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new CandlehearthCoffee();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new CandlehearthCoffee();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new CandlehearthCoffee();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                bool set = (bool)a[prop] ? false : true;
                a[prop] = set;
                Assert.Equal(set, (bool)a[prop]);
            }
        }

        [Fact]
        public void EnumOptionsShouldContainAllSizes()
        {
            var a = new CandlehearthCoffee();
            var d = a.EnumOptions;
            Assert.Contains(Size.Small, d["Size"]);
            Assert.Contains(Size.Medium, d["Size"]);
            Assert.Contains(Size.Large, d["Size"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new CandlehearthCoffee();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new CandlehearthCoffee();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new CandlehearthCoffee();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}
