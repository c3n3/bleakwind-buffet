/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: SmokehouseSkeletonTests.cs
 * Purpose: Test the SmokehouseSkeleton.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class SmokehouseSkeletonTests
    {        
        [Fact]
        public void ShouldInlcudeSausageByDefault()
        {
            Assert.True((new SmokehouseSkeleton()).SausageLink);
        }

        [Fact]
        public void ShouldInlcudeEggByDefault()
        {
            Assert.True((new SmokehouseSkeleton()).Egg);
        }

        [Fact]
        public void ShouldInlcudeHashbrownsByDefault()
        {
            Assert.True((new SmokehouseSkeleton()).HashBrowns);
        }

        [Fact]
        public void ShouldInlcudePancakeByDefault()
        {
            Assert.True((new SmokehouseSkeleton()).Pancake);
        }

        [Fact]
        public void ShouldBeAbleToSetSausage()
        {
            var a = new SmokehouseSkeleton();
            a.SausageLink = false;
            Assert.False(a.SausageLink);
        }

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            var a = new SmokehouseSkeleton();
            a.Egg = false;
            Assert.False(a.Egg);
        }

        [Fact]
        public void ShouldBeAbleToSetHashbrowns()
        {
            var a = new SmokehouseSkeleton();
            a.HashBrowns = false;
            Assert.False(a.HashBrowns);
        }

        [Fact]
        public void ShouldBeAbleToSetPancake()
        {
            var a = new SmokehouseSkeleton();
            a.Pancake= false;
            Assert.False(a.Pancake);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(5.62, (new SmokehouseSkeleton()).Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)602, (new SmokehouseSkeleton()).Calories);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSausage, bool includeEgg,
                                                            bool includeHashbrowns, bool includePancake)
        {
            var a = new SmokehouseSkeleton()
            {
                Pancake = includePancake,
                SausageLink = includeSausage,
                Egg = includeEgg,
                HashBrowns = includeHashbrowns,
            };
            if (includeEgg)
            {
                Assert.DoesNotContain("Hold pancake", a.SpecialInstructions);
                Assert.DoesNotContain("Hold sausage", a.SpecialInstructions);
                Assert.DoesNotContain("Hold eggs", a.SpecialInstructions);
                Assert.DoesNotContain("Hold hash browns", a.SpecialInstructions);
                return;
            }
            Assert.Contains("Hold pancake", a.SpecialInstructions);
            Assert.Contains("Hold sausage", a.SpecialInstructions);
            Assert.Contains("Hold eggs", a.SpecialInstructions);
            Assert.Contains("Hold hash browns", a.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Smokehouse Skeleton", (new SmokehouseSkeleton()).ToString());
        }
    }
}