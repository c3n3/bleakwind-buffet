using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    /// <summary>
    /// Event args for a checkbox
    /// </summary>
    public class CheckboxEventArgs : EventArgs
    {
        /// <summary>
        /// If it is on
        /// </summary>
        public bool On { get; private set; }

        /// <summary>
        /// The option this event pertains to
        /// </summary>
        public string Option { get; private set; }

        /// <summary>
        /// This is the ctor
        /// </summary>
        /// <param name="opt"> option </param>
        /// <param name="o"> the on </param>
        public CheckboxEventArgs(string opt, bool o)
        {
            Option = opt;
            On = o;
        }
    }
}
