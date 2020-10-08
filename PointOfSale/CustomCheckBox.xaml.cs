/*
 * Author: Caden Churchman
 * Class: CustomCheckBox
 * Purpose: Makes a custom checkbox
 */
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
    /// Interaction logic for CustomCheckBox.xaml
    /// </summary>
    public partial class CustomCheckBox : UserControl
    {
        /// <summary>
        /// This is the switched event handler
        /// </summary>
        public event EventHandler Switched;

        //private string ex = "Images\\ex.png";
        //private string check = "Images\\check.png";

        /// <summary>
        /// If it is on
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        /// Makes dependency property for data binding
        /// </summary>
        public static readonly DependencyProperty OnProperty =
            DependencyProperty.Register(
            "On", typeof(bool),
            typeof(CustomCheckBox)
            );

        /// <summary>
        /// Value 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The check box
        /// </summary>
        /// <param name="value"> the value </param>
        /// <param name="on"> if it is on </param>
        public CustomCheckBox(string value, bool on)
        {
            InitializeComponent();
            On = on;
            SetImage();
            Value = value;
            value_label.Content = value;
        }

        /// <summary>
        /// Sets the image
        /// </summary>
        private void SetImage()
        {
            if (On)
            {
                check.Visibility = Visibility.Visible;
                ex.Visibility = Visibility.Hidden;
            }
            else
            {
                check.Visibility = Visibility.Hidden;
                ex.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Mouse up click
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> event </param>
        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            On = !On;
            Switched?.Invoke(this, new CheckboxEventArgs(Value, On));
            SetImage();
        }
    }
}
