/*
 * Author: Zachery Brunner
 * Edited By Caden Churchman
 * Class: DragonbornWaffleFriesTests.cs
 * Purpose: Test the DragonbornWaffleFries.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;
using System;
using System.Runtime;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
   public class DragonbornWaffleFriesTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new DragonbornWaffleFries());
		}

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new DragonbornWaffleFries();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void SizeShouldChangePrice()
        {
            var a = new DragonbornWaffleFries();
            Assert.PropertyChanged(a, "Price", () => a.Size = Size.Large);
        }

        [Fact]
        public void SizeShouldChangeCalories()
        {
            var a = new DragonbornWaffleFries();
            Assert.PropertyChanged(a, "Calories", () => a.Size = Size.Large);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var a = new DragonbornWaffleFries();
            Assert.Equal(Size.Small, a.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new DragonbornWaffleFries();
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            Assert.Empty((new DragonbornWaffleFries()).SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 0.42)]
        [InlineData(Size.Medium, 0.76)]
        [InlineData(Size.Large, 0.96)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            var a = new DragonbornWaffleFries();
            a.Size = size;
            Assert.Equal(price, a.Price);
        }

        [Theory]
        [InlineData(Size.Small, 77)]
        [InlineData(Size.Medium, 89)]
        [InlineData(Size.Large, 100)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            var a = new DragonbornWaffleFries();
            a.Size = size;
            Assert.Equal(calories, a.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Dragonborn Waffle Fries")]
        [InlineData(Size.Medium, "Medium Dragonborn Waffle Fries")]
        [InlineData(Size.Large, "Large Dragonborn Waffle Fries")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var a = new DragonbornWaffleFries();
            a.Size = size;
            Assert.Equal(name, a.ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new DragonbornWaffleFries();
            Assert.IsAssignableFrom<Side>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new DragonbornWaffleFries();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeEmpty()
        {
            Assert.Empty((new DragonbornWaffleFries()).BoolOptions);
        }

        [Fact]
        public void EnumOptionsShouldContainAllSizes()
        {
            var a = new DragonbornWaffleFries();
            var d = a.EnumOptions;
            Assert.Contains(Size.Small, d["Size"]);
            Assert.Contains(Size.Medium, d["Size"]);
            Assert.Contains(Size.Large, d["Size"]);
        }
        
        [Fact]
        public void EnumOptionsShouldBeSetable()
        {
            var a = new DragonbornWaffleFries();
            var d = a.EnumOptions;
            foreach (var kv in d)
            {
                a[kv.Key] = kv.Value[0];
            }
        } 
        
        [Fact]
        public void EnumOptionsShouldBeGetable()
        {
            var a = new DragonbornWaffleFries();
            var d = a.EnumOptions;
            foreach (var kv in d)
            {
                var g = a[kv.Key];
                Assert.NotNull(a);
            }
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new DragonbornWaffleFries();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new DragonbornWaffleFries();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new DragonbornWaffleFries();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}