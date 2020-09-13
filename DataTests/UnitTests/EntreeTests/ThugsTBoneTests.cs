/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: ThugsTBoneTests.cs
 * Purpose: Test the ThugsTBone.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class ThugsTBoneTests
    {
        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(6.44, (new ThugsTBone()).Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)982, (new ThugsTBone()).Calories);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            Assert.Empty((new ThugsTBone()).SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Thugs T-Bone", (new ThugsTBone()).ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new ThugsTBone();
            Assert.IsAssignableFrom<Entree>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new ThugsTBone();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }
    }
}