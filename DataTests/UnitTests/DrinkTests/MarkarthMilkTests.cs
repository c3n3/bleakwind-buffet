/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: MarkarthMilkTests.cs
 * Purpose: Test the MarkarthMilk.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    public class MarkarthMilkTests
    {
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
    }
}