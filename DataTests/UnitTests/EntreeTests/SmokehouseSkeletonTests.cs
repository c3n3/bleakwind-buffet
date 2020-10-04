/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: SmokehouseSkeletonTests.cs
 * Purpose: Test the SmokehouseSkeleton.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
   public class SmokehouseSkeletonTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new SmokehouseSkeleton());
		}

        [Fact]
        public void AllBooleanPropertiesShouldNotifyOfChange()
        {
            SmokehouseSkeleton a = new SmokehouseSkeleton();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, option, () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new SmokehouseSkeleton();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void AllBoolOptionsShouldChangeSpecialInstructions()
        {
            SmokehouseSkeleton a = new SmokehouseSkeleton();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => a[option] = !(bool)a[option]);
            }
        }
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
                Assert.DoesNotContain("Hold pancakes", a.SpecialInstructions);
                Assert.DoesNotContain("Hold sausage", a.SpecialInstructions);
                Assert.DoesNotContain("Hold eggs", a.SpecialInstructions);
                Assert.DoesNotContain("Hold hash browns", a.SpecialInstructions);
                return;
            }
            Assert.Contains("Hold pancakes", a.SpecialInstructions);
            Assert.Contains("Hold sausage", a.SpecialInstructions);
            Assert.Contains("Hold eggs", a.SpecialInstructions);
            Assert.Contains("Hold hash browns", a.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Smokehouse Skeleton", (new SmokehouseSkeleton()).ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new SmokehouseSkeleton();
            Assert.IsAssignableFrom<Entree>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new SmokehouseSkeleton();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new SmokehouseSkeleton();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new SmokehouseSkeleton();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                bool set = (bool)a[prop] ? false : true;
                a[prop] = set;
                Assert.Equal(set, (bool)a[prop]);
            }
        }

        [Fact]
        public void EnumOptionsShouldBeEmpty()
        {
            var a = new SmokehouseSkeleton();
            var d = a.EnumOptions;
            Assert.Empty(d);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new SmokehouseSkeleton();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new SmokehouseSkeleton();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new SmokehouseSkeleton();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}