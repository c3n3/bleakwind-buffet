/*
 * Author: Caden Churchman
 * Class: WarriorWater.cs
 * Purpose: Test the WarriorWater.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;
using BleakwindBuffet.Data.Menu;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    public class WarriorWaterTests
    {
        [Fact]
        public void ShouldIncludeIceByDefault()
        {
            WarriorWater a = new WarriorWater();
            Assert.True(a.Ice);
        }
        
        [Fact]
        public void ShouldNotIncludeLemonByDefault()
        {
            WarriorWater a = new WarriorWater();
            Assert.False(a.Lemon);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var a = new WarriorWater();
            Assert.Equal(Size.Small, a.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var a = new WarriorWater();
            a.Ice = false;
            Assert.False(a.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new WarriorWater();
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
            a.Size = Size.Large;
            Assert.Equal(Size.Large, a.Size);
        }

        [Fact]
        public void WaterIsFree()
        {
            var a = new WarriorWater();
            Assert.Equal(0, a.Price);
        }

        [Fact]
        public void WaterHasNoCalories()
        {
            var a = new WarriorWater();
            Assert.Equal((uint)0, a.Calories);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeLemon)
        {
            var a = new WarriorWater();
            a.Ice = includeIce;
            a.Lemon = includeLemon;
            if (includeIce)
            {
                Assert.Contains("Add lemon", a.SpecialInstructions);
                return;
            } else if (!includeLemon) 
            {
                Assert.Contains("Hold ice", a.SpecialInstructions);
            }
        }

        [Theory]
        [InlineData(Size.Small, "Small Warrior Water")]
        [InlineData(Size.Medium, "Medium Warrior Water")]
        [InlineData(Size.Large, "Large Warrior Water")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var a = new WarriorWater();
            a.Size = size;
            Assert.Equal(name, a.ToString());
        }


        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new WarriorWater();
            Assert.IsAssignableFrom<Drink>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new WarriorWater();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new WarriorWater();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new WarriorWater();
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
            var a = new WarriorWater();
            var d = a.EnumOptions;
            Assert.Contains(Size.Small, d["Size"]);
            Assert.Contains(Size.Medium, d["Size"]);
            Assert.Contains(Size.Large, d["Size"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new WarriorWater();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new WarriorWater();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new WarriorWater();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}
