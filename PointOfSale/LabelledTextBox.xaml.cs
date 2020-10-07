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
        public static readonly DependencyProperty LabelProp = DependencyProperty.Register("Label", typeof(string), typeof(LabelledTextBox), new FrameworkPropertyMetadata("TEST"));
        public static readonly DependencyProperty ValueProp = DependencyProperty.Register("Value", typeof(string), typeof(LabelledTextBox), new FrameworkPropertyMetadata("TEST"));
        public LabelledTextBox()
        {
            InitializeComponent();
            uxGrid.DataContext = this;
        }

        public string Label
        {
            get => (string)GetValue(LabelProp);
            set
            {
                SetValue(LabelProp, value);
            }
        }

        public string Value {
            get
            {
                return (string)GetValue(ValueProp);
            }
            set
            {
                double t;
                if (Double.TryParse(value, out t))
                {
                    SetValue(LabelProp, Math.Round(t, 2));
                }
                SetValue(ValueProp, value);
            }
        }
    }
}
