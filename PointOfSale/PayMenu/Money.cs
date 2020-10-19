/*
 * Author: Caden Churchman
 * Class: Money...
 * Purpose: Makes a crap ton of money classes
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.PayMenu.Monies
{
	/// <summary>
	/// Repressents a set of a certain money
	/// </summary>
    abstract public class Money : INotifyPropertyChanged
    {
		/// <summary>
		/// The values 
		/// </summary>
        public abstract double Value { get; }

		/// <summary>
		/// The count of monies
		/// </summary>
        public abstract int Count { get; set; }

		/// <summary>
		/// is coin
		/// </summary>
        public abstract bool IsCoin { get; }

		/// <summary>
		/// A value string
		/// </summary>
		public string ValueString
        {
			get => Value >= 1 ? $"${Value}" : $"{Value * 100}c";
        }

		/// <summary>
		/// all the monies
		/// </summary>
		/// <returns></returns>
		public static List<Money> AllMonies()
        {
			return new List<Money> { new Hundreds(), new Fifties(), new Twenties(), new Tens(), new Fives(), new Twos(), new Ones(), new Dollars(), new HalfDollars(), new Quarters(), new Dimes(), new Nickels(), new Pennies() };
        }

		/// <summary>
		/// name
		/// </summary>
        public string Name => GetType().Name;
		/// <summary>
		/// prop changed
		/// </summary>
        public abstract event PropertyChangedEventHandler PropertyChanged;
    }
	/// <summary>
	/// pennies
	/// </summary>
    public class Pennies : Money
    {
		/// <summary>
		/// value  
		/// </summary>
        public override double Value => 0.01;
		/// <summary>
		/// count 
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0)	return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;
		/// <summary>
		/// void 
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// public 
		/// </summary>
        public override bool IsCoin => true;
    }
    
	/// <summary>
	/// nickels
	/// </summary>
    public class Nickels : Money
    {
		/// <summary>
		/// Value
		/// </summary>
        public override double Value => 0.05;

		/// <summary>
		/// Count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;
		/// <summary>
		/// Prop changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// is coin
		/// </summary>
        public override bool IsCoin => true;
    }    
	/// <summary>
	/// dimes 
	/// </summary>
    public class Dimes : Money
    {
		/// <summary>
		/// Value 
		/// </summary>
        public override double Value => 0.1;

		/// <summary>
		/// Count 
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;
		/// <summary>
		/// handler 
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// is coing 
		/// </summary>
        public override bool IsCoin => true;
    }    
    public class Quarters : Money
    {
		/// <summary>
		/// Value 
		/// </summary>
        public override double Value => 0.25;

		/// <summary>
		/// Count 
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;

		/// <summary>
		/// The property handler
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Is coin
		/// </summary>
        public override bool IsCoin => true;
    }
    public class Dollars : Money
    {
		/// <summary>
		/// The value
		/// </summary>
        public override double Value => 1;

		/// <summary>
		/// Count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;

		/// <summary>
		/// Property changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// is coin
		/// </summary>
        public override bool IsCoin => true;
    }
	/// <summary>
	/// the money of the thing
	/// </summary>
    public class HalfDollars : Money
    {
		/// <summary>
		/// Value 
		/// </summary>
		public override double Value => 0.5;

		/// <summary>
		/// The count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;

		/// <summary>
		/// prop changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// This is th ecoimng
		/// </summary>
        public override bool IsCoin => true;
    }
	/// <summary>
	/// The ones 
	/// </summary>
    public class Ones : Money
    {
		/// <summary>
		/// Value
		/// </summary>
        public override double Value => 1;
		/// <summary>
		/// Count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;
		/// <summary>
		/// prop changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// is coin
		/// </summary>
        public override bool IsCoin => false;
    }
	/// <summary>
	/// twos
	/// </summary>
    public class Twos : Money
    {
		/// <summary>
		/// Value
		/// </summary>
        public override double Value => 2;

		/// <summary>
		/// Count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;
		/// <summary>
		/// prop changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// is coin
		/// </summary>
        public override bool IsCoin => false;
    }
	/// <summary>
	/// finves
	/// </summary>
    public class Fives : Money
    {
		/// <summary>
		/// is value
		/// </summary>
        public override double Value => 5;
		/// <summary>
		/// Is Cont
		/// </summary>
        public override bool IsCoin => false;
		/// <summary>
		/// Count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;
		/// <summary>
		/// popr canged
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
    }
	/// <summary>
	/// Tens
	/// </summary>
    public class Tens : Money
    {
		/// <summary>
		/// the value
		/// </summary>
        public override double Value => 10;

		/// <summary>
		/// is coin
		/// </summary>
        public override bool IsCoin => false;

		/// <summary>
		/// Count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		private int _count = 0;
		/// <summary>
		/// Prop changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
    }
	/// <summary>
	/// twenties
	/// </summary>
    public class Twenties : Money
    {
		/// <summary>
		/// Value
		/// </summary>
        public override double Value => 20;
		/// <summary>
		/// is coinf
		/// </summary>
        public override bool IsCoin => false;
		/// <summary>
		/// count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		/// <summary>
		/// count
		/// </summary>
		private int _count = 0;
		/// <summary>
		/// the property changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
    }

	/// <summary>
	/// fifites
	/// </summary>
    public class Fifties : Money
    {
		/// <summary>
		/// isoing
		/// </summary>
        public override bool IsCoin => false;
		/// <summary>
		/// valuye
		/// </summary>
        public override double Value => 50;
		/// <summary>
		/// count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		/// <summary>
		/// count
		/// </summary>
		private int _count = 0;
		/// <summary>
		/// the prop
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
    }
    public class Hundreds : Money
    {
		/// <summary>
		/// is coin
		/// </summary>
        public override bool IsCoin => false;
		/// <summary>
		/// Value
		/// </summary>
        public override double Value => 100;
		/// <summary>
		/// /count
		/// </summary>
        public override int Count
		{
			get {
				return _count;
			} set {
				if (value < 0) return;
				_count = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
			}
		}
		/// <summary>
		/// c
		/// </summary>
		private int _count = 0;
		/// <summary>
		/// Prop changed
		/// </summary>
		public override event PropertyChangedEventHandler PropertyChanged;
    }
}
