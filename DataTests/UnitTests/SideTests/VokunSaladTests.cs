/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: VokunSaladTests.cs
 * Purpose: Test the VokunSalad.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
   public class VokunSaladTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new VokunSalad());
		}

        [Fact]
        public void AllBooleanPropertiesShouldNotifyOfChange()
        {
            VokunSalad a = new VokunSalad();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, option, () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new VokunSalad();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void AllBoolOptionsShouldChangeSpecialInstructions()
        {
            VokunSalad a = new VokunSalad();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void SizeShouldChangePrice()
        {
            var a = new VokunSalad();
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
            var a = new VokunSalad();
            Assert.Equal(Size.Small, a.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new VokunSalad();
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
            a.Size = Size.Large;
            Assert.Equal(Size.Large, a.Size);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            Assert.Empty((new VokunSalad()).SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 0.93)]
        [InlineData(Size.Medium, 1.28)]
        [InlineData(Size.Large, 1.82)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            var a = new VokunSalad();
            a.Size = size;
            Assert.Equal(price, a.Price);
        }

        [Theory]
        [InlineData(Size.Small, 41)]
        [InlineData(Size.Medium, 52)]
        [InlineData(Size.Large, 73)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            var a = new VokunSalad();
            a.Size = size;
            Assert.Equal(calories, a.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Vokun Salad")]
        [InlineData(Size.Medium, "Medium Vokun Salad")]
        [InlineData(Size.Large, "Large Vokun Salad")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var a = new VokunSalad();
            a.Size = size;
            Assert.Equal(name, a.ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new VokunSalad();
            Assert.IsAssignableFrom<Side>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new VokunSalad();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new VokunSalad();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new VokunSalad();
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
            var a = new VokunSalad();
            var d = a.EnumOptions;
            Assert.Contains(Size.Small, d["Size"]);
            Assert.Contains(Size.Medium, d["Size"]);
            Assert.Contains(Size.Large, d["Size"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new VokunSalad();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new VokunSalad();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new VokunSalad();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}