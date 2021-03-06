﻿/*
 * Author: Zachery Brunner
* Edited By Caden Churchman
 * Class: BriarheartBurgerTests.cs
 * Purpose: Test the BriarheartBurger.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using System.Collections.Generic;
using System;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
   public class BriarheartBurgerTests
    {
		[Fact]
		public void ShouldBeConvertableToINotifyPropertyChanged()
		{
			Assert.IsAssignableFrom<System.ComponentModel.INotifyPropertyChanged>(new BriarheartBurger());
		}

        [Fact]
        public void AllBooleanPropertiesShouldNotifyOfChange()
        {
            BriarheartBurger a = new BriarheartBurger();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, option, () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void AllEnumPropertiesShouldNotifyOfChange()
        {
            var a = new BriarheartBurger();
            foreach (var kv in a.EnumOptions)
            {
                Assert.PropertyChanged(a, kv.Key, () => a[kv.Key] = kv.Value[0]);
            }
        }

        [Fact]
        public void AllBoolOptionsShouldChangeSpecialInstructions()
        {
            BriarheartBurger a = new BriarheartBurger();
            foreach (var option in a.BoolOptions)
            {
                Assert.PropertyChanged(a, "SpecialInstructions", () => a[option] = !(bool)a[option]);
            }
        }

        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            var a = new BriarheartBurger();
            Assert.True(a.Bun);
        }

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            var a = new BriarheartBurger();
            Assert.True(a.Ketchup);
        }

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            var a = new BriarheartBurger();
            Assert.True(a.Mustard);
        }

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            var a = new BriarheartBurger();
            Assert.True(a.Pickle);
        }

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            var a = new BriarheartBurger();
            Assert.True(a.Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            var a = new BriarheartBurger();
            a.Bun = false;
            Assert.False(a.Bun);
        }

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            var a = new BriarheartBurger();
            a.Ketchup = false;
            Assert.False(a.Ketchup);
        }

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            var a = new BriarheartBurger();
            a.Mustard= false;
            Assert.False(a.Mustard);
        }

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            var a = new BriarheartBurger();
            a.Pickle= false;
            Assert.False(a.Pickle);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var a = new BriarheartBurger();
            a.Cheese= false;
            Assert.False(a.Cheese);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            var a = new BriarheartBurger();
            Assert.Equal(6.32, a.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            var a = new BriarheartBurger();
            Assert.Equal<uint>(743, a.Calories);
        }

        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese)
        {
            var a = new BriarheartBurger();
            a.Bun = includeBun;
            a.Ketchup = includeKetchup;
            a.Mustard = includeMustard;
            a.Pickle = includePickle;
            a.Cheese = includeCheese;
            if (includeCheese)
            {
                Assert.DoesNotContain("Hold cheese", a.SpecialInstructions);
            } else
            {
                Assert.Contains("Hold cheese", a.SpecialInstructions);
            }
            if (includeMustard)
            {
                Assert.DoesNotContain("Hold mustard", a.SpecialInstructions);
            } else
            {
                Assert.Contains("Hold mustard", a.SpecialInstructions);
            }
            if (includeKetchup)
            {
                Assert.DoesNotContain("Hold ketchup", a.SpecialInstructions);
            } else
            {
                Assert.Contains("Hold ketchup", a.SpecialInstructions);
            }
            if (includePickle)
            {
                Assert.DoesNotContain("Hold pickle", a.SpecialInstructions);
            } else
            {
                Assert.Contains("Hold pickle", a.SpecialInstructions);
            }
            if (includeBun)
            {
                Assert.DoesNotContain("Hold bun", a.SpecialInstructions);
            } else
            {
                Assert.Contains("Hold bun", a.SpecialInstructions);
            }
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            var a = new BriarheartBurger();
            Assert.Equal("Briarheart Burger", a.ToString());
        }


        [Fact]
        public void ShouldBeAssignabledToBaseClass()
        {
            var a = new BriarheartBurger();
            Assert.IsAssignableFrom<Entree>(a);
        }

        [Fact]
        public void ShouldBeAssignableToIOrderItem()
        {
            var a = new BriarheartBurger();
            Assert.IsAssignableFrom<IOrderItem>(a);
        }

        [Fact]
        public void BooleanOptionsArrayShouldReturnValidProperties()
        {
            var a = new BriarheartBurger();
            List<string> props = a.BoolOptions;

            foreach (string prop in props)
            {
                Assert.IsType<bool>(a[prop]);
            }
        }

        [Fact]
        public void BooleanOptionsArrayShouldBeSetable()
        {
            var a = new BriarheartBurger();
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
            var a = new BriarheartBurger();
            var d = a.EnumOptions;
            Assert.Empty(d);
        }

        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorForInvalidProperty()
        {
            var a = new BriarheartBurger();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"]);
        }
        
        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidValue()
        {
            var a = new BriarheartBurger();
            Assert.Throws<ArgumentException>(() => a["Price"] = "INVALID VALUE");
        }
        
        [Fact]
        public void ClassAccessorMethodShouldThrowArgumentErrorWhenSettingWithInvalidPropertyName()
        {
            var a = new BriarheartBurger();
            Assert.Throws<ArgumentException>(() => a["INVALID PROPERTY"] = 1);
        }
    }
}