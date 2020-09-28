/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: DoubleDraugrTests.cs
 * Purpose: Test the DoubleDraugr.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class DoubleDraugrTests
    {   
        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Bun);
        }

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Ketchup);
        }

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Mustard);
        }

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Pickle);
        }

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Cheese);
        }

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Tomato);
        }

        [Fact]
        public void ShouldIncludeLettuceByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Lettuce);
        }

        [Fact]
        public void ShouldIncludeMayoByDefault()
        {
            var a = new DoubleDraugr();
            Assert.True(a.Mayo);
        }

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            var a = new DoubleDraugr();
            a.Bun = false;
            Assert.False(a.Bun);
        }

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            var a = new DoubleDraugr();
            a.Ketchup = false;
            Assert.False(a.Ketchup);
        }

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            var a = new DoubleDraugr();
            a.Mustard = false;
            Assert.False(a.Mustard);
        }

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            var a = new DoubleDraugr();
            a.Pickle = false;
            Assert.False(a.Pickle);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var a = new DoubleDraugr();
            a.Cheese = false;
            Assert.False(a.Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            var a = new DoubleDraugr();
            a.Tomato = false;
            Assert.False(a.Tomato);
        }

        [Fact]
        public void ShouldBeAbleToSetLettuce()
        {
            var a = new DoubleDraugr();
            a.Lettuce = false;
            Assert.False(a.Lettuce);
        }

        [Fact]
        public void ShouldBeAbleToSetMayo()
        {
            var a = new DoubleDraugr();
            a.Mayo = false;
            Assert.False(a.Mayo);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(7.32, (new DoubleDraugr()).Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal<uint>(843, (new DoubleDraugr()).Calories);
        }

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo)
        {
            var a = new DoubleDraugr()
            {
                Bun = includeBun,
                Ketchup = includeKetchup,
                Pickle = includePickle,
                Lettuce = includeLettuce,
                Mustard = includeMustard,
                Mayo = includeMayo,
                Cheese = includeCheese,
                Tomato = includeTomato
            };

            // all test are same so this will work
            if (includeTomato)
            {
                Assert.DoesNotContain("Hold tomato", a.SpecialInstructions);
                Assert.DoesNotContain("Hold mayo", a.SpecialInstructions);
                Assert.DoesNotContain("Hold pickle", a.SpecialInstructions);
                Assert.DoesNotContain("Hold ketchup", a.SpecialInstructions);
                Assert.DoesNotContain("Hold cheese", a.SpecialInstructions);
                Assert.DoesNotContain("Hold mustard", a.SpecialInstructions);
                Assert.DoesNotContain("Hold bun", a.SpecialInstructions);
                Assert.DoesNotContain("Hold lettuce", a.SpecialInstructions);
                return;
            }
            Assert.Contains("Hold tomato", a.SpecialInstructions);
            Assert.Contains("Hold mayo", a.SpecialInstructions);
            Assert.Contains("Hold pickle", a.SpecialInstructions);
            Assert.Contains("Hold ketchup", a.SpecialInstructions);
            Assert.Contains("Hold cheese", a.SpecialInstructions);
            Assert.Contains("Hold mustard", a.SpecialInstructions);
            Assert.Contains("Hold bun", a.SpecialInstructions);
            Assert.Contains("Hold lettuce", a.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Double Draugr", (new DoubleDraugr()).ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new DoubleDraugr();
            Assert.IsAssignableFrom<Entree>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new DoubleDraugr();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new DoubleDraugr();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new DoubleDraugr();
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
            var a = new DoubleDraugr();
            var d = a.EnumOptions;
            Assert.Empty(d);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new DoubleDraugr();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new DoubleDraugr();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new DoubleDraugr();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}