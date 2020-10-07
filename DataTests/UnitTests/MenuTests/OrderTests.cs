using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.MenuTests
{
    public class OrderTests
    {
        [Fact]
        public void OrdersShouldIncrementNumber()
        {
            var a = new Order();
            var b = new Order();
            Assert.Equal(0, a.Number);
            Assert.Equal(1, b.Number);
        }

        [Fact]
        public void OrderCaloriesShouldBeAdditionOfAllElemnts()
        {
            var a = new Order();
            var b = new BriarheartBurger();
            var c = new SailorSoda();
            a.Add(b);
            a.Add(c);
            Assert.Equal(a.Calories, b.Calories + c.Calories);
        }

        [Fact]
        public void SubtotalShouldBeTotalOfElements()
        {
            var a = new Order();
            var b = new BriarheartBurger();
            var c = new SailorSoda();
            a.Add(b);
            a.Add(c);
            Assert.Equal(a.Subtotal, b.Price + c.Price);
        }

        [Fact]
        public void TotalIsSubPlusTax()
        {
            var a = new Order();
            var b = new BriarheartBurger();
            var c = new SailorSoda();
            a.Add(b);
            a.Add(c);
            Assert.Equal(a.Total, a.Tax + a.Subtotal);
        }

        [Fact]
        public void OrderIsINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new Order());
        }
        
        [Fact]
        public void OrderIsICollectionChanged()
        {
            Assert.IsAssignableFrom<INotifyCollectionChanged>(new Order());
        }

        [Fact]
        public void AddingElementNotifiesSubtotal()
        {
            var a = new Order();
            Assert.PropertyChanged(a, "Subtotal", () => a.Add(new BriarheartBurger()));
        }
        
        [Fact]
        public void AddingElementNotifiesTotal()
        {
            var a = new Order();
            Assert.PropertyChanged(a, "Total", () => a.Add(new BriarheartBurger()));
        }
        
        [Fact]
        public void AddingElementNotifiesCalories()
        {
            var a = new Order();
            Assert.PropertyChanged(a, "Calories", () => a.Add(new BriarheartBurger()));
        }
        
        [Fact]
        public void AddingElementNotifiesTax()
        {
            var a = new Order();
            Assert.PropertyChanged(a, "Tax", () => a.Add(new BriarheartBurger()));
        }

        [Fact]
        public void RemovingItemNotifiesSubtotal()
        {
            var a = new Order();
            var b = new BriarheartBurger();
            a.Add(b);
            Assert.PropertyChanged(a, "Subtotal", () => a.Remove(b));
        }

        [Fact]
        public void RemovingItemNotifiesTax()
        {
            var a = new Order();
            var b = new BriarheartBurger();
            a.Add(b);
            Assert.PropertyChanged(a, "Tax", () => a.Remove(b));
        }

        [Fact]
        public void RemovingItemNotifiesCalories()
        {
            var a = new Order();
            var b = new BriarheartBurger();
            a.Add(b);
            Assert.PropertyChanged(a, "Calories", () => a.Remove(b));
        }

        [Fact]
        public void RemovingItemNotifiesTotal()
        {
            var a = new Order();
            var b = new BriarheartBurger();
            a.Add(b);
            Assert.PropertyChanged(a, "Total", () => a.Remove(b));
        }

        [Fact]
        public void SubItemPriceChangeNotifiesTotal()
        {
            var a = new Order();
            var b = new DragonbornWaffleFries();
            a.Add(b);
            Assert.PropertyChanged(a, "Total", () => b.Size = Data.Enums.Size.Large);
        }

        [Fact]
        public void SubItemPriceChangeNotifiesSubTotal()
        {
            var a = new Order();
            var b = new DragonbornWaffleFries();
            a.Add(b);
            Assert.PropertyChanged(a, "Subtotal", () => b.Size = Data.Enums.Size.Large);
        }

        [Fact]
        public void SubItemPriceChangeNotifiesTax()
        {
            var a = new Order();
            var b = new DragonbornWaffleFries();
            a.Add(b);
            Assert.PropertyChanged(a, "Tax", () => b.Size = Data.Enums.Size.Large);
        }

        [Fact]
        public void ItemNotifiesOfSubItemCaloryChange()
        {
            var a = new Order();
            var b = new DragonbornWaffleFries();
            a.Add(b);
            Assert.PropertyChanged(a, "Calories", () => b.Size = Data.Enums.Size.Large);
        }

        [Fact]
        public void OrderCanChangeSalesTaxRate()
        {
            var a = new Order();
            a.SalesTaxRate = 1;
            Assert.Equal(1, a.SalesTaxRate);
        }

        [Fact]
        public void OrderNotifiesSalesTaxChange()
        {
            var a = new Order();
            Assert.PropertyChanged(a, "SalesTaxRate", () => a.SalesTaxRate = 2);
        }

        [Fact]
        public void OrderNotifiesSalesTaxChangeForTax()
        {
            var a = new Order();
            Assert.PropertyChanged(a, "Tax", () => a.SalesTaxRate = 2);
        }
        
        [Fact]
        public void OrderNotifiesSalesTaxChangeForTotal()
        {
            var a = new Order();
            Assert.PropertyChanged(a, "Total", () => a.SalesTaxRate = 2);
        }

        [Fact]
        public void SalesTaxNonChangeDoesNotNotify()
        {
            var a = new Order();
            a.PropertyChanged += (object s, PropertyChangedEventArgs e) => { Assert.False(true); };
            a.SalesTaxRate = a.SalesTaxRate;
        }

        [Fact]
        public void OrderImplementsCollectionIsSynchronized()
        {
            var a = new Order();
            Assert.False(a.IsSynchronized);
        }

        [Fact]
        public void CountIsCorrect()
        {
            var a = new Order();
            Assert.Equal(0, a.Count);
            a.Add(new BriarheartBurger());
            Assert.Equal(1, a.Count);
        }

        [Fact]
        public void AssertSyncRootIsThis()
        {
            var a = new Order();
            Assert.IsAssignableFrom<Order>(a.SyncRoot);
        }

        [Fact]
        public void OrderIsIterable()
        {
            var a = new Order();
            a.Add(new BriarheartBurger());
            a.Add(new DragonbornWaffleFries());
            foreach (var i in a)
            {
                Assert.IsAssignableFrom<IOrderItem>(i);
            }
        }

        [Fact]
        public void OrderCanCopyTo()
        {
            IOrderItem[] a = new IOrderItem[1];
            var b = new Order();
            b.Add(new BriarheartBurger());
            b.CopyTo(a, 0);
            Assert.IsAssignableFrom<Entree>(a[0]);
        }
    }
}
