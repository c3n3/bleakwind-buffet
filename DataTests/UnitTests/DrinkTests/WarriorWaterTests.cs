/*
 * Author: Caden Churchman
 * Class: WarriorWater.cs
 * Purpose: Test the WarriorWater.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;

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
    }
}
