using BleakwindBuffet.Data.Entrees;
using PointOfSale.PayMenu.Monies;
using RoundRegister;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PointOfSale.PayMenu
{
    /// <summary>
    /// The "Cache" Drawer
    /// </summary>
    public class CacheDrawer : INotifyPropertyChanged
    {
        /// <summary>
        /// The proposed monies
        /// </summary>
        public List<Monies.Money> PaymentMonies = Monies.Money.AllMonies();

        /// <summary>
        /// The monies 
        /// </summary>
        public List<Monies.Money> CacheRegisterMonies = Monies.Money.AllMonies();

        /// <summary>
        /// Torder cost
        /// </summary>
        private double _orderCost;

        /// <summary>
        /// ya
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="orderCost"></param>
        public CacheDrawer(double orderCost)
        {
            ResetDrawer();
            UpdateSelfToReg();
            foreach (var m in PaymentMonies)
            {
                m.PropertyChanged += PaymentMoniesChanged;
            }
            foreach (var m in CacheRegisterMonies)
            {
                m.PropertyChanged += CacheRegisterMoneyChanged;
            }
            _orderCost = orderCost;
        }

        /// <summary>
        /// This pays the monies
        /// </summary>
        public void Pay()
        {
            if (!TransactionAvailable) return;
            List<Monies.Money> change = Change;
            OpenDrawer();
            AddToReg(PaymentMonies);
            PaymentMonies.ForEach(x => x.Count = 0);
            RemoveFromReg(change);
        }

        /// <summary>
        /// This adds the monies to the register
        /// </summary>
        /// <param name="monies"></param>
        public void AddToReg(List<Monies.Money> monies)
        {
            foreach (var money in monies)
            {
                var a = CacheRegisterMonies.Find(x => x.Name == money.Name);
                if (a != null)
                {
                    a.Count += money.Count;
                }

            }
        }

        /// <summary>
        /// Remove the listed monies from the register
        /// </summary>
        /// <param name="monies">monies to remove</param>
        public void RemoveFromReg(List<Monies.Money> monies)
        {
            foreach (var money in monies)
            {
                var a = CacheRegisterMonies.Find(x => x.Name == money.Name);
                if (a != null)
                {
                    a.Count -= money.Count;
                }

            }
        }
        
        /// <summary>
        /// This updates self to be the register
        /// </summary>
        public void UpdateSelfToReg()
        {
            foreach (var money in CacheRegisterMonies)
            {
                var a = CacheRegisterMonies.Find(x => x.Name == money.Name);
                if (a != null)
                {
                    money.Count = a.Count;
                }
            }
        }

        /// <summary>
        /// When the monies in the register change we need to update our list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CacheRegisterMoneyChanged(object sender, EventArgs e) 
        {
            if (sender is Monies.Money m)
            {
                typeof(CashDrawer).GetField(m.Name).SetValue(null, m.Count);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
            }
        }

        /// <summary>
        /// This is the changed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PaymentMoniesChanged(object sender, EventArgs e)
        {
            if (sender is Monies.Money)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Remainder"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountDue"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Change"));
                
            }
        }

        /// <summary>
        /// opens the drawer? Why?
        /// </summary>
        public void OpenDrawer()
        {
            CashDrawer.OpenDrawer();
        }

        /// <summary>
        /// The reset drawer
        /// </summary>
        public void ResetDrawer()
        {
            CashDrawer.ResetDrawer();
            foreach (var m in CacheRegisterMonies)
            {

                var a = typeof(CashDrawer).GetField(m.Name);
                if (a != null)
                {
                    m.Count = (int)a.GetValue(null);
                }
            }
        }

        /// <summary>
        /// The remainder
        /// </summary>
        public double Remainder
        {
            get
            {
                double totalInput = PaymentMonies.Sum(x => x.Value * x.Count);
                if (totalInput > _orderCost)
                {
                    return Math.Round(totalInput - _orderCost, 2);
                }
                return 0;
            }
        }

        /// <summary>
        /// The cost
        /// </summary>
        public double Cost => _orderCost;

        /// <summary>
        /// The amount due
        /// </summary>
        public double AmountDue
        {
            get
            {
                double totalInput = PaymentMonies.Sum(x => x.Value * x.Count);
                if (totalInput < _orderCost)
                {
                    return Math.Round(_orderCost - totalInput, 2);
                }
                return 0;
            }
        }

        /// <summary>
        /// Property for the function to bind
        /// </summary>
        public List<Monies.Money> Change => GetChange();

        /// <summary>
        /// The change message
        /// </summary>
        public string ProvideChangeMessage
        {
            get => TransactionAvailable ? "Returned Change: " : AmountDue == 0 ? "Not enough funds in register." : "";
        }

        /// <summary>
        /// Gets the change given the proposed payment and the register values
        /// </summary>
        /// <returns></returns>
        public List<Monies.Money> GetChange()
        {
            List<Monies.Money> temp = Monies.Money.AllMonies();
            
            
            int remainder = Convert.ToInt32(Remainder * 100); // no messing with double nonsense for this

            if (AmountDue != 0)
            {
                TransactionAvailable = false;
                return new List<Monies.Money>();
            }

            List<List<object>> counts = CacheRegisterMonies.Select(x => {
                return new List<object> { x.Count, x.Name, x.Value };
            }).ToList();

            //we can always hand back their own change
            counts.ForEach(x => x[0] = (int)x[0] + PaymentMonies.Find(z => z.Name == (string)x[1]).Count);

            foreach (var a in counts)
            {
                int value = Convert.ToInt32(((double)a[2]) * 100);
                while ((int)a[0] != 0)
                {
                    if (remainder >= value)
                    {
                        temp.Find(x => x.Name == (string)a[1]).Count++;
                        a[0] = ((int)a[0]) - 1;
                        remainder -= value;
                    } else
                    {
                        break;
                    }
                }
            }
            if (remainder != 0)
            {
                TransactionAvailable = false;
                return new List<Monies.Money>();
            } 
            TransactionAvailable = true;
            temp = temp.Where(x => x.Count != 0).ToList();
            return temp;
        }

        /// <summary>
        /// Tells if payment is even possible
        /// </summary>
        public bool TransactionAvailable
        {
            get 
            {
                return _transactionAvailable;
            }
            set
            {
                _transactionAvailable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TransactionAvailable"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProvideChangeMessage"));
            }
        }
        private bool _transactionAvailable = false;
    }
}
