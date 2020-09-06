/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: GardenOrcOmeletteTests.cs
 * Purpose: Test the GardenOrcOmelette.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class GardenOrcOmeletteTests
    {
        [Fact]
        public void ShouldInlcudeBroccoliByDefault()
        {
            Assert.True((new GardenOrcOmelette()).Broccoli);
        }

        [Fact]
        public void ShouldInlcudeMushroomsByDefault()
        {
            Assert.True((new GardenOrcOmelette()).Mushrooms);
        }

        [Fact]
        public void ShouldInlcudeTomatoByDefault()
        {
            Assert.True((new GardenOrcOmelette()).Tomato);
        }

        [Fact]
        public void ShouldInlcudeCheddarByDefault()
        {
            Assert.True((new GardenOrcOmelette()).Cheddar);
        }

        [Fact]
        public void ShouldBeAbleToSetBroccoli()
        {
            var a = new GardenOrcOmelette();
            a.Broccoli = false;
            Assert.False(a.Broccoli);
        }

        [Fact]
        public void ShouldBeAbleToSetMushrooms()
        {
            var a = new GardenOrcOmelette();
            a.Mushrooms = false;
            Assert.False(a.Mushrooms);
        }

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            var a = new GardenOrcOmelette();
            a.Tomato = false;
            Assert.False(a.Tomato);
        }

        [Fact]
        public void ShouldBeAbleToSetCheddar()
        {
            var a = new GardenOrcOmelette();
            a.Cheddar = false;
            Assert.False(a.Cheddar);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(4.57, (new GardenOrcOmelette()).Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)404, (new GardenOrcOmelette()).Calories);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBroccoli, bool includeMushrooms,
                                                            bool includeTomato, bool includeCheddar)
        {
            var a = new GardenOrcOmelette()
            {
                Broccoli = includeBroccoli,
                Mushrooms = includeMushrooms,
                Tomato = includeTomato,
                Cheddar = includeCheddar,
            };
            if (includeBroccoli)
            {
                Assert.DoesNotContain("Hold broccoli", a.SpecialInstructions);
                Assert.DoesNotContain("Hold mushrooms", a.SpecialInstructions);
                Assert.DoesNotContain("Hold tomato", a.SpecialInstructions);
                Assert.DoesNotContain("Hold cheddar", a.SpecialInstructions);
                return;
            }
            Assert.Contains("Hold broccoli", a.SpecialInstructions);
            Assert.Contains("Hold mushrooms", a.SpecialInstructions);
            Assert.Contains("Hold tomato", a.SpecialInstructions);
            Assert.Contains("Hold cheddar", a.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Garden Orc Omelette", (new GardenOrcOmelette()).ToString());
        }
    }
}