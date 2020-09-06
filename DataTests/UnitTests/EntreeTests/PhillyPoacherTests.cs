/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: PhillyPoacherTests.cs
 * Purpose: Test the PhillyPoacher.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class PhillyPoacherTests
    {
        [Fact]
        public void ShouldInlcudeSirloinByDefault()
        {
            Assert.True((new PhillyPoacher()).Sirloin);
        }

        [Fact]
        public void ShouldInlcudeOnionByDefault()
        {
            Assert.True((new PhillyPoacher()).Onion);
        }

        [Fact]
        public void ShouldInlcudeRollByDefault()
        {
            Assert.True((new PhillyPoacher()).Roll);
        }

        [Fact]
        public void ShouldBeAbleToSetSirloin()
        {
            var a = new PhillyPoacher();
            a.Sirloin = false;
            Assert.False(a.Sirloin);
        }

        [Fact]
        public void ShouldBeAbleToSetOnions()
        {
            var a = new PhillyPoacher();
            a.Onion = false;
            Assert.False(a.Onion);
        }

        [Fact]
        public void ShouldBeAbleToSetRoll()
        {
            var a = new PhillyPoacher();
            a.Roll = false;
            Assert.False(a.Roll);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(7.23, (new PhillyPoacher()).Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)784, (new PhillyPoacher()).Calories);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSirloin, bool includeOnion,
                                                            bool includeRoll)
        {
            var a = new PhillyPoacher()
            {
                Sirloin = includeSirloin,
                Roll = includeRoll,
                Onion = includeOnion,
            };
            if (includeOnion)
            {
                Assert.DoesNotContain("Hold onion", a.SpecialInstructions);
                Assert.DoesNotContain("Hold roll", a.SpecialInstructions);
                Assert.DoesNotContain("Hold sirloin", a.SpecialInstructions);
                return;
            }
            Assert.Contains("Hold onion", a.SpecialInstructions);
            Assert.Contains("Hold roll", a.SpecialInstructions);
            Assert.Contains("Hold sirloin", a.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Philly Poacher", (new PhillyPoacher()).ToString());
        }
    }
}