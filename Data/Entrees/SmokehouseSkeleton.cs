/*
* Author: Caden Churchman
* Class name: SmokehouseSkeleton.cs
* Purpose: Represents the breakfast item.
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{   
    /// <summary>
    /// Represents the smokehouse skeleton.
    /// </summary>
    public class SmokehouseSkeleton: Entree
    {
		/// <summary>
		/// Description
		/// </summary>
		public override string Description => "Put some meat on those bones with a small stack of pancakes. Includes sausage links, eggs, and hash browns on the side. Topped with the syrup of your choice.";

        /// <summary>
        /// Property Changed event handler
        /// </summary>
        public override event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool SausageLink { 
			get 
 			{
				return _sausageLink;
			}
			set
			{
				_sausageLink = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SausageLink"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _sausageLink = true;
        
        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool Egg { 
			get 
 			{
				return _egg;
			}
			set
			{
				_egg = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Egg"));
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
;
			}
		} 
		private bool _egg = true;

        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool Pancake
        {
            get
            {
                return _pancake;
            }
            set
            {
                _pancake = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Pancake"));
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
                ;
            }
        }
        private bool _pancake = true;

        /// <summary>
        /// Gets the link.
        /// </summary>
        public bool HashBrowns
        {
            get
            {
                return _hashBrowns;
            }
            set
            {
                _hashBrowns = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("HashBrowns"));
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("SpecialInstructions"));
                ;
            }
        }
        private bool _hashBrowns = true;

        /// <summary>
        /// Gets instructions.
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                var l = new List<string> { };
                if (!Egg) l.Add("Hold eggs");
                if (!HashBrowns) l.Add("Hold hash browns");
                if (!Pancake) l.Add("Hold pancakes");
                if (!SausageLink) l.Add("Hold sausage");
                return l;

            }
        }

        /// <summary>
        /// The pirce.
        /// </summary>
        public override double Price => 5.62;

        /// <summary>
        /// The calories.
        /// </summary>
        public override uint Calories => 602;

        /// <summary>
        /// To string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }
    }
}
