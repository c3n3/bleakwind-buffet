/*
 * Author: Caden Churchman
 * Class: LabelledTextBox
 * Purpose: The creation of a simpe labeled value system
 */
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
    /// Interaction logic for LabelledTextBox.xaml
    /// </summary>
    public partial class LabelledTextBox : UserControl
    {
        /// <summary>
        /// This is the label prop
        /// </summary>
        public static readonly DependencyProperty LabelProp = DependencyProperty.Register("Label", typeof(string), typeof(LabelledTextBox), new FrameworkPropertyMetadata("TEST"));

        /// <summary>
        /// This is the value dependency prop
        /// </summary>
        public static readonly DependencyProperty ValueProp = DependencyProperty.Register("Value", typeof(string), typeof(LabelledTextBox), new FrameworkPropertyMetadata("TEST"));

        /// <summary>
        /// Clicked thing
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// This is the Ctor
        /// </summary>
        public LabelledTextBox()
        {
            InitializeComponent();
            uxGrid.DataContext = this;
        }

        /// <summary>
        /// The label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The value of the label
        /// </summary>
        public string Value { get; set; }
    }
}
