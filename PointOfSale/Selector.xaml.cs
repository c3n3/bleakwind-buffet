/*
 * Author: Caden Churchman
 * Class: Selector
 * Purpose: Utilizes the radial buttons to make a selector menu for the given vailable options.
 */
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : UserControl
    {
        /// <summary>
        /// Event to handle when new thing selected
        /// </summary>
        public event EventHandler Selected;

        /// <summary>
        /// The possible options
        /// </summary>
        public List<object> Options = new List<object>();

        /// <summary>
        /// The current value
        /// </summary>
        public object Value;

        /// <summary>
        /// The label value or the corresponding key 
        /// </summary>
        public string Key = "";

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="opts"> the possible options</param>
        /// <param name="initial"> the initial value </param>
        /// <param name="label"> the label value or "Key"</param>
        public Selector(List<object> opts, object initial, string label)
        {
            InitializeComponent();
            Value = initial;
            Options = opts;
            key.Content = label;
            Key = label;
            Grid.SetZIndex(options, 99);
        }


        /// <summary>
        /// Renders all the radial buttons
        /// </summary>
        public void RenderOptions()
        {
            int index = 0;
            for (double i = 0; i < Math.PI * 2 - 0.1; i += 2 * Math.PI / (Options.Count)) 
            {
                var a = new RadialButton(new Point(ActualWidth / 2, ActualHeight / 2), 2 * Math.PI / (Options.Count + 1), i, ActualHeight / 4, Options[index++]);
                a.Clicked += DeleteOptions;
                options.Children.Add(a);
                Grid.SetZIndex(a, 1000);
                Canvas.SetZIndex(a, 1000);
            }
        }

        /// <summary>
        /// Deletes all the options
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> e e</param>
        public void DeleteOptions(object sender, EventArgs e)
        {
            if (sender is RadialButton r)
            {
                Value = r.Value;
                Selected?.Invoke(this, e);
            }
            options.Children.Clear();
        }
           
        /// <summary>
        /// The event handler for clicking the button
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> e </param>
        private void ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RenderOptions();
        }

        /// <summary>
        /// The mouse leaft the seen
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> e </param>
        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            DeleteOptions(sender, e);
        }
    }
}
