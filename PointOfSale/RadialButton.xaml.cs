using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for CircleFragmentButton.xaml
    /// </summary>
    public partial class RadialButton : UserControl
    {
        /// <summary>
        /// The clicked event handler
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// The Center of the button
        /// </summary>
        public Point _center = new Point(0, 0);

        /// <summary>
        /// The width angle 
        /// </summary>
        public double _widthAngle = Math.PI / 2;

        /// <summary>
        /// Self explainatory 
        /// </summary>
        public double _directionalAngle = Math.PI / 2;

        /// <summary>
        /// The length of the middle arc
        /// </summary>
        public double _length = 0;

        /// <summary>
        /// The value
        /// </summary>
        public object Value { get; set; }

        //public RadialButton()
        //{
        //    InitializeComponent();
        //    Ctor(new Point(200, 200), Math.PI / 6, Math.PI / 4, 100);
        //}

        /// <summary>
        /// Constuction a new radial button
        /// </summary>
        /// <param name="c"> the center </param>
        /// <param name="wa"> the width angle </param>
        /// <param name="da"> the direction angle </param>
        /// <param name="l"> the lenghth thing </param>
        /// <param name="v"> the value </param>
        public RadialButton(Point c, double wa, double da, double l, object v)
        {
            Value = v;
            InitializeComponent();
            da = da + Math.PI;
            _center = c;
            _widthAngle = wa;
            _directionalAngle = da;
            _length = l;
            var ps = new PointCollection(4);
            var p1 = FindP1();
            var p2 = FindP2();
            ps.Add(_center);
            ps.Add(p1);
            var L = Point.Subtract(p2, p1).Length;
            var p3 = new Point((L / 2 + _length) * Math.Cos(da) + _center.X, (L / 2 + _length) * Math.Sin(da) + _center.Y);
            ps.Add(p3);
            ps.Add(p2);
            //Poly.Points = ps;
            double fontSize = _length / 2;
            Poly.Opacity = 0;
            


            t.FontSize = fontSize;
            t.Text = Value.ToString();
            t.Foreground = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(textBorder, (_length) * Math.Cos(da) + _center.X - ActualWidth / 2);
            Canvas.SetTop(textBorder, (_length) * Math.Sin(da) + _center.Y - ActualHeight / 2);
            //Canvas.SetLeft(textBorder, p3.X - ActualWidth / 2);
            //Canvas.SetTop(textBorder, p3.Y - ActualHeight / 2);
            RotateTransform r = new RotateTransform(da * 180 / Math.PI, 0, 0);
            textBorder.RenderTransform = r;
        }

        /// <summary>
        /// Finds p1 for th polygon DEPRECATED
        /// </summary>
        /// <returns> The point </returns>
        private Point FindP1()
        {
            return new Point(
                _center.X + _length * Math.Sin(Math.PI / 2 - _directionalAngle - _widthAngle / 2) / Math.Cos(_widthAngle / 2),
                _center.Y + _length * Math.Cos(Math.PI / 2 - _directionalAngle - _widthAngle / 2) / Math.Cos(_widthAngle / 2)
            );
        }

        /// <summary>
        /// Finds p2 for the polygon DEPCRECATED
        /// </summary>
        /// <returns> the point </returns>
        private Point FindP2()
        {
            return new Point(
                _center.X + _length * Math.Cos(_directionalAngle - _widthAngle / 2) / Math.Cos(_widthAngle / 2),
                _center.Y + _length * Math.Sin(_directionalAngle - _widthAngle / 2) / Math.Cos(_widthAngle / 2)
            );
        }

        /// <summary>
        /// The event handler
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the event </param>
        private void Poly_MouseLeftButtonUp(object sender, EventArgs e)
        {
            Clicked(this, e);
        }
    }
}
