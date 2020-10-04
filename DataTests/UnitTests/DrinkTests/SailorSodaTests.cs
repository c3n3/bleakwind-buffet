/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: SailorSodaTests.cs
 * Purpose: Test the SailorSoda.cs class in the Data library
 */
using System;

using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
   public class SailorSodaTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new SailorSoda());
		}

        [Fact]
        public void AllBooleanPropertiesShouldNotifyOfChange()
        {
            SailorSoda a = new SailorSoda();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, option, () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new SailorSoda();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void AllBoolOptionsShouldChangeSpecialInstructions()
        {
            SailorSoda a = new SailorSoda();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void SizeShouldChangePrice()
        {
            var a = new SailorSoda();
            Assert.PropertyChanged(a, "Price", () => a.Size = Size.Large);
        }

        [Fact]
        public void SizeShouldChangeCalories()
        {
            var a = new SailorSoda();
            Assert.PropertyChanged(a, "Calories", () => a.Size = Size.Large);
        }

        [Fact]
        public void ShouldIncludeIceByDefault()
        {
            var a = new SailorSoda();
            Assert.True(a.Ice);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var a = new SailorSoda();
            Assert.Equal(Size.Small, a.Size);
        }

        [Fact]
        public void FlavorShouldBeCherryByDefault()
        {
            var a = new SailorSoda();
            Assert.Equal(SodaFlavor.Cherry, a.Flavor);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var a = new SailorSoda();
            a.Ice = false;
            Assert.False(a.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new SailorSoda();
            a.Size = Size.Large;
            Assert.Equal(Size.Large, a.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetFlavor()
        {
            var a = new SailorSoda();
            a.Flavor = SodaFlavor.Blackberry;
            Assert.Equal(SodaFlavor.Blackberry, a.Flavor);
        }

        [Theory]
        [InlineData(Size.Small, 1.42)]
        [InlineData(Size.Medium, 1.74)]
        [InlineData(Size.Large, 2.07)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var a = new SailorSoda();
            a.Size = size;
            Assert.Equal(price, a.Price);
        }

        [Theory]
        [InlineData(Size.Small, 117)]
        [InlineData(Size.Medium, 153)]
        [InlineData(Size.Large, 205)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var a = new SailorSoda();
            a.Size = size;
            Assert.Equal(cal, a.Calories);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce)
        {
            var a = new SailorSoda();
            a.Ice = includeIce;
            if (includeIce)
            {
                Assert.DoesNotContain("Hold ice", a.SpecialInstructions);
                return;
            }
            Assert.Contains("Hold ice", a.SpecialInstructions);
        }
        
        [Theory]
        [InlineData(SodaFlavor.Cherry, Size.Small, "Small Cherry Sailor Soda")]
        [InlineData(SodaFlavor.Cherry, Size.Medium, "Medium Cherry Sailor Soda")]
        [InlineData(SodaFlavor.Cherry, Size.Large, "Large Cherry Sailor Soda")]

        [InlineData(SodaFlavor.Blackberry, Size.Small, "Small Blackberry Sailor Soda")]
        [InlineData(SodaFlavor.Blackberry, Size.Medium, "Medium Blackberry Sailor Soda")]
        [InlineData(SodaFlavor.Blackberry, Size.Large, "Large Blackberry Sailor Soda")]

        [InlineData(SodaFlavor.Grapefruit, Size.Small, "Small Grapefruit Sailor Soda")]
        [InlineData(SodaFlavor.Grapefruit, Size.Medium, "Medium Grapefruit Sailor Soda")]
        [InlineData(SodaFlavor.Grapefruit, Size.Large, "Large Grapefruit Sailor Soda")]

        [InlineData(SodaFlavor.Lemon, Size.Small, "Small Lemon Sailor Soda")]
        [InlineData(SodaFlavor.Lemon, Size.Medium, "Medium Lemon Sailor Soda")]
        [InlineData(SodaFlavor.Lemon, Size.Large, "Large Lemon Sailor Soda")]

        [InlineData(SodaFlavor.Peach, Size.Small, "Small Peach Sailor Soda")]
        [InlineData(SodaFlavor.Peach, Size.Medium, "Medium Peach Sailor Soda")]
        [InlineData(SodaFlavor.Peach, Size.Large, "Large Peach Sailor Soda")]

        [InlineData(SodaFlavor.Watermelon, Size.Small, "Small Watermelon Sailor Soda")]
        [InlineData(SodaFlavor.Watermelon, Size.Medium, "Medium Watermelon Sailor Soda")]
        [InlineData(SodaFlavor.Watermelon, Size.Large, "Large Watermelon Sailor Soda")]
        public void ShouldHaveCorrectToStringBasedOnSizeAndFlavor(SodaFlavor flavor, Size size, string name)
        {
            var a = new SailorSoda();
            a.Size = size;
            a.Flavor = flavor;
            Assert.Equal(name, a.ToString());
        }


        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new SailorSoda();
            Assert.IsAssignableFrom<Drink>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new SailorSoda();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new SailorSoda();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new SailorSoda();
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
            var a = new SailorSoda();
            var d = a.EnumOptions;
            Assert.Contains(Size.Small, d["Size"]);
            Assert.Contains(Size.Medium, d["Size"]);
            Assert.Contains(Size.Large, d["Size"]);
        }
        
        [Fact]
        public void EnumOptionsShouldContainAllFlavors()
        {
            var a = new SailorSoda();
            var d = a.EnumOptions;
            Assert.Contains(SodaFlavor.Blackberry, d["Flavor"]);
            Assert.Contains(SodaFlavor.Cherry, d["Flavor"]);
            Assert.Contains(SodaFlavor.Grapefruit, d["Flavor"]);
            Assert.Contains(SodaFlavor.Lemon, d["Flavor"]);
            Assert.Contains(SodaFlavor.Peach, d["Flavor"]);
            Assert.Contains(SodaFlavor.Watermelon, d["Flavor"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new SailorSoda();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new SailorSoda();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new SailorSoda();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}
