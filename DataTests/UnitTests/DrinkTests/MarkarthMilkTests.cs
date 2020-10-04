/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: MarkarthMilkTests.cs
 * Purpose: Test the MarkarthMilk.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
   public class MarkarthMilkTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new MarkarthMilk());
		}

        [Fact]
        public void AllBooleanPropertiesShouldNotifyOfChange()
        {
            MarkarthMilk a = new MarkarthMilk();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, option, () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new MarkarthMilk();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void AllBoolOptionsShouldChangeSpecialInstructions()
        {
            MarkarthMilk a = new MarkarthMilk();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void SizeShouldChangePrice()
        {
            var a = new MarkarthMilk();
            Assert.PropertyChanged(a, "Price", () => a.Size = Size.Large);
        }

        [Fact]
        public void SizeShouldChangeCalories()
        {
            var a = new MarkarthMilk();
            Assert.PropertyChanged(a, "Calories", () => a.Size = Size.Large);
        }

        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
            Assert.False((new MarkarthMilk()).Ice);
        }

        [Fact]
        public void ShouldBySmallByDefault()
        {
            Assert.Equal(Size.Small, (new MarkarthMilk()).Size);
        }

        [Fact]
        public void ShouldByAbleToSetIce()
        {
            var a = new MarkarthMilk();
            a.Ice = false;
            Assert.False(a.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new MarkarthMilk();
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
            a.Size = Size.Large;
            Assert.Equal(Size.Large, a.Size);
        }

        [Theory]
        [InlineData(Size.Small, 1.05)]
        [InlineData(Size.Medium, 1.11)]
        [InlineData(Size.Large, 1.22)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var a = new MarkarthMilk();
            a.Size = size;
            Assert.Equal(price, a.Price);
        }

        [Theory]
        [InlineData(Size.Small, 56)]
        [InlineData(Size.Medium, 72)]
        [InlineData(Size.Large, 93)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var a = new MarkarthMilk();
            a.Size = size;
            Assert.Equal(cal, a.Calories);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce)
        {
            var a = new MarkarthMilk();
            a.Ice = includeIce;
            if (includeIce)
            {
                Assert.Contains("Add ice", a.SpecialInstructions);
                return;
            }
            Assert.Empty(a.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, "Small Markarth Milk")]
        [InlineData(Size.Medium, "Medium Markarth Milk")]
        [InlineData(Size.Large, "Large Markarth Milk")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var a = new MarkarthMilk();
            a.Size = size;
            Assert.Equal(name, a.ToString());
        }


        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new MarkarthMilk();
            Assert.IsAssignableFrom<Drink>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new MarkarthMilk();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new MarkarthMilk();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new MarkarthMilk();
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
            var a = new MarkarthMilk();
            var d = a.EnumOptions;
            Assert.Contains(Size.Small, d["Size"]);
            Assert.Contains(Size.Medium, d["Size"]);
            Assert.Contains(Size.Large, d["Size"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new MarkarthMilk();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new MarkarthMilk();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new MarkarthMilk();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}