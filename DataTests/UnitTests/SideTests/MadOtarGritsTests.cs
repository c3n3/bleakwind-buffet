﻿/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: MadOtarGritsTests.cs
 * Purpose: Test the MadOtarGrits.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
   public class MadOtarGritsTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new MadOtarGrits());
		}

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new MadOtarGrits();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void SizeShouldChangePrice()
        {
            var a = new MadOtarGrits();
            Assert.PropertyChanged(a, "Price", () => a.Size = Size.Large);
        }

        [Fact]
        public void SizeShouldChangeCalories()
        {
            var a = new MadOtarGrits();
            Assert.PropertyChanged(a, "Calories", () => a.Size = Size.Large);
        }


        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var a = new MadOtarGrits();
            Assert.Equal(Size.Small, a.Size);
        }
                
        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new MadOtarGrits();
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
        }

        [Fact]
        public void ShouldReturnCorrectStringOnSpecialInstructions()
        {
            Assert.Empty((new MadOtarGrits()).SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 1.22)]
        [InlineData(Size.Medium, 1.58)]
        [InlineData(Size.Large, 1.93)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            var a = new MadOtarGrits();
            a.Size = size;
            Assert.Equal(price, a.Price);
        }

        [Theory]
        [InlineData(Size.Small, 105)]
        [InlineData(Size.Medium, 142)]
        [InlineData(Size.Large, 179)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            var a = new MadOtarGrits();
            a.Size = size;
            Assert.Equal(calories, a.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Mad Otar Grits")]
        [InlineData(Size.Medium, "Medium Mad Otar Grits")]
        [InlineData(Size.Large, "Large Mad Otar Grits")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var a = new MadOtarGrits();
            a.Size = size;
            Assert.Equal(name, a.ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new MadOtarGrits();
            Assert.IsAssignableFrom<Side>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new MadOtarGrits();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeEmpty()
        {
            Assert.Empty((new MadOtarGrits()).BoolOptions);
        }

        [Fact]
        public void EnumOptionsShouldContainAllSizes()
        {
            var a = new MadOtarGrits();
            var d = a.EnumOptions;
            Assert.Contains(Size.Small, d["Size"]);
            Assert.Contains(Size.Medium, d["Size"]);
            Assert.Contains(Size.Large, d["Size"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new MadOtarGrits();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new MadOtarGrits();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new MadOtarGrits();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}