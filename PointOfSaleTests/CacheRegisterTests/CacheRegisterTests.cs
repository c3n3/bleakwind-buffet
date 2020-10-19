using PointOfSale.PayMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.wpfTests
{
    public class CacheRegisterTests
    {
        [Fact]
        public void AllMoniesShouldNotifyProp()
        {
            var a = new CacheDrawer(10);
            foreach (var m in a.CacheRegisterMonies)
            {
                Assert.PropertyChanged(m, "Count", () => m.Count++);
            }
        }

        [Fact]
        public void CacheDrawerShouldNotify()
        {
            var a = new CacheDrawer(10);
            foreach (var m in a.CacheRegisterMonies)
            {
                Assert.PropertyChanged(a, "Change", () => m.Count++);
            }
            foreach (var m in a.PaymentMonies)
            {
                Assert.PropertyChanged(a, "Remainder", () => m.Count++);
                Assert.PropertyChanged(a, "AmountDue", () => m.Count++);
                Assert.PropertyChanged(a, "Change", () => m.Count++);
            }
        }

        [Fact]
        public void AllMoniesShouldBeINotifyPropertyChanged()
        {
            var a = PointOfSale.PayMenu.Monies.Money.AllMonies();
            foreach (var m in a)
            {
                Assert.IsAssignableFrom<INotifyPropertyChanged>(m);
            }
        }

        [Fact]
        public void AllMoniesHaveStringValue()
        {
            var a = PointOfSale.PayMenu.Monies.Money.AllMonies();
            foreach (var m in a)
            {
                Assert.IsType<string>(m.ValueString);
            }
        }

        [Fact]
        public void AllMoniesCannotGoNegative()
        {
            var a = PointOfSale.PayMenu.Monies.Money.AllMonies();
            foreach (var m in a)
            {
                m.Count = -1;
                Assert.Equal(0, m.Count);
            }
        }

        [Fact]
        public void ChangeProvidedMessageChanges()
        {
            var a = new CacheDrawer(10);
            a.ResetDrawer();
            string init = a.ProvideChangeMessage;
            a.PaymentMonies.ForEach(x =>
            {
                if (x.Name == "Tens")
                    x.Count++;
            });
            Assert.NotEqual(a.ProvideChangeMessage, init);
        }
        
        [Fact]
        public void TransactionIsChanged()
        {
            var a = new CacheDrawer(10);
            a.ResetDrawer();
            Assert.False(a.TransactionAvailable);
            foreach (var m in a.PaymentMonies)
            {
                if (m.Name == "Tens")
                {
                    m.Count++;
                }
            }
            //Assert.True(a.TransactionAvailable);
        }

        [Fact]
        public void AllMoniesPropsCanBeGet()
        {
            var a = PointOfSale.PayMenu.Monies.Money.AllMonies();
            foreach (var m in a)
            {
                Assert.IsType<int>(m.Count);
                m.Count = 90;
                Assert.Equal(90, m.Count);
                Assert.IsType<double>(m.Value);
                Assert.IsType<bool>(m.IsCoin);
                Assert.IsType<string>(m.Name);
            }
        }
    }
}
