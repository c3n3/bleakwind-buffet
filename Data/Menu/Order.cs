using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace BleakwindBuffet.Data.Menu
{
    /// <summary>
    /// This is a collection class that represents an order
    /// </summary>
    public class Order : ICollection, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// The number of the order
        /// </summary>
        public int Number { get; } = _orderIndex++;

        /// <summary>
        /// Gets all orders a unique number unless of course they order over 2^32 things
        /// </summary>
        private static int _orderIndex = 0;

        /// <summary>
        /// _items in order
        /// </summary>
        List<IOrderItem> _items = new List<IOrderItem>();

        /// <summary>
        /// Collection changed
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        public void Add(IOrderItem item)
        {
            item.PropertyChanged += ItemChangedEventListener;
            _items.Add(item);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"> the item </param>
        public void Remove(IOrderItem item)
        {
            item.PropertyChanged -= ItemChangedEventListener;
            _items.Remove(item);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }

        /// <summary>
        /// listens for property changes in items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ItemChangedEventListener(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IOrderItem item)
            {
                if (e.PropertyName == "Price")
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
                }
                else if (e.PropertyName == "Calories")
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                }
            }
        }

        /// <summary>
        /// Gets the calories of the items
        /// </summary>
        public uint Calories => (uint)_items.Sum(item => item.Calories);

        /// <summary>
        /// This copies the array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            foreach (var item in _items)
            {
                array.SetValue(item, index++);
            }
        }

        /// <summary>
        /// This gets an enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator(); 
        }

        /// <summary>
        /// This is the sales tax applied to the order
        /// </summary>
        public double SalesTaxRate
        {
            get
            {
                return _salesTax;
            }
            set
            {
                if (_salesTax == value) return;
                _salesTax = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SalesTaxRate"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            }
        }
        private double _salesTax = 0.12;

        /// <summary>
        /// This is the subtotal for the order
        /// </summary>
        public double Subtotal => _items.Sum(i => i.Price);

        /// <summary>
        /// This is the tax amount for the order
        /// </summary>
        public double Tax => _items.Sum(i => i.Price) * SalesTaxRate;

        /// <summary>
        /// This is the total total
        /// </summary>
        public double Total => Subtotal + Tax;

        /// <summary>
        /// The count
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Definitley not
        /// </summary>
        public bool IsSynchronized => false;

        /// <summary>
        /// Ya is this like a semaphore or a mutext or something?
        /// </summary>
        public object SyncRoot => this;
    }
}
