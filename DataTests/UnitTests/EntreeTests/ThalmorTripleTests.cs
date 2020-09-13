/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: ThalmorTripleTests.cs
 * Purpose: Test the ThalmorTriple.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class ThalmorTripleTests
    {
        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Bun);
        }

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Ketchup);
        }

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Mustard);
        }

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Pickle);
        }

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Cheese);
        }

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Tomato);
        }

        [Fact]
        public void ShouldIncludeLettuceByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Lettuce);
        }

        [Fact]
        public void ShouldIncludeMayoByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Mayo);
        }

        [Fact]
        public void ShouldIncludeBaconByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Bacon);
        }

        [Fact]
        public void ShouldIncludeEggByDefault()
        {
            var a = new ThalmorTriple();
            Assert.True(a.Egg);
        }

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            var a = new ThalmorTriple();
            a.Bun = false;
        }

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            var a = new ThalmorTriple();
            a.Ketchup = false;
        }

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            var a = new ThalmorTriple();
            a.Mustard = false;

        }

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            var a = new ThalmorTriple();
            a.Pickle = false;
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var a = new ThalmorTriple();
            a.Cheese = false;
        }

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            var a = new ThalmorTriple();
            a.Tomato = false;
        }

        [Fact]
        public void ShouldBeAbleToSetLettuce()
        {
            var a = new ThalmorTriple();
            a.Lettuce = false;
        }

        [Fact]
        public void ShouldBeAbleToSetMayo()
        {
            var a = new ThalmorTriple();
            a.Mayo = false;
        }

        [Fact]
        public void ShouldBeAbleToSetBacon()
        {
            var a = new ThalmorTriple();
            a.Bacon = false;
        }

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            var a = new ThalmorTriple();
            a.Egg = false;
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(8.32, (new ThalmorTriple()).Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)943, (new ThalmorTriple()).Calories);
        }

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo,
                                                                    bool includeBacon, bool includeEgg)
        {
            var a = new ThalmorTriple()
            {
                Bun = includeBun,
                Ketchup = includeKetchup,
                Pickle = includePickle,
                Lettuce = includeLettuce,
                Mustard = includeMustard,
                Mayo = includeMayo,
                Cheese = includeCheese,
                Tomato = includeTomato,
                Bacon = includeBacon,
                Egg = includeEgg
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
                Assert.DoesNotContain("Hold bacon", a.SpecialInstructions);
                Assert.DoesNotContain("Hold egg", a.SpecialInstructions);
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
            Assert.Contains("Hold bacon", a.SpecialInstructions);
            Assert.Contains("Hold egg", a.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Thalmor Triple", (new ThalmorTriple()).ToString());
        }

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new ThalmorTriple();
            Assert.IsAssignableFrom<Entree>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new ThalmorTriple();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }
    }
}