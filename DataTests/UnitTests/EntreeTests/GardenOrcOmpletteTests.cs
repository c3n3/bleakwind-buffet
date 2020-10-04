/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: GardenOrcOmeletteTests.cs
 * Purpose: Test the GardenOrcOmelette.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
   public class GardenOrcOmeletteTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new GardenOrcOmelette());
		}

        [Fact]
        public void AllBooleanPropertiesShouldNotifyOfChange()
        {
            GardenOrcOmelette a = new GardenOrcOmelette();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, option, () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new GardenOrcOmelette();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void AllBoolOptionsShouldChangeSpecialInstructions()
        {
            GardenOrcOmelette a = new GardenOrcOmelette();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => a[option] = !(bool)a[option]);
            }
        }

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

        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new GardenOrcOmelette();
            Assert.IsAssignableFrom<Entree>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new GardenOrcOmelette();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new GardenOrcOmelette();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new GardenOrcOmelette();
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
            var a = new GardenOrcOmelette();
            var d = a.EnumOptions;
            Assert.Empty(d);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new GardenOrcOmelette();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new GardenOrcOmelette();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new GardenOrcOmelette();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}