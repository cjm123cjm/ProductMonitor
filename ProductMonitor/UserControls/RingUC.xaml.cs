using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
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

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// RingUC.xaml 的交互逻辑
    /// </summary>
    public partial class RingUC : UserControl
    {
        public RingUC()
        {
            InitializeComponent();
            SizeChanged += RingUC_SizeChanged;
        }

        private void RingUC_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drug();
        }

        public double PercentValue
        {
            get
            {
                return (double)GetValue(PercentValueProperty);
            }
            set
            {
                SetValue(PercentValueProperty, value);
            }
        }
        public static readonly DependencyProperty PercentValueProperty =
            DependencyProperty.Register("PercentValue", typeof(double), typeof(RingUC));

        /// <summary>
        /// 画圆环
        /// </summary>
        private void Drug()
        {
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            LayOutGrid.Width = size;
            LayOutGrid.Height = size;

            double radius = size / 2;

            double x = radius + (radius - 3) * Math.Cos((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);
            double y = radius + (radius - 3) * Math.Sin((PercentValue % 100 * 3.6 - 90) * Math.PI / 180);

            int Is50 = PercentValue < 50 ? 0 : 1;
            string pathStr = $"M{radius + 0.01} 3A{radius - 3} {radius - 3} 0 {Is50} 1 {x} {y}";
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            path.Data = (Geometry)converter.ConvertFrom(pathStr);
        }
    }
}
