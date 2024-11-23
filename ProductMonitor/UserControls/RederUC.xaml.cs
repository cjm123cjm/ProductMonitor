using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// RederUC.xaml 的交互逻辑
    /// </summary>
    public partial class RederUC : UserControl
    {
        public RederUC()
        {
            InitializeComponent();

            SizeChanged += RederUC_SizeChanged;
        }

        /// <summary>
        /// 窗口发生大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RederUC_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }

        /// <summary>
        /// 数据源。支持数据绑定，依赖属性
        /// </summary>
        public List<RaderModel> ItemSource
        {
            get
            {
                return (List<RaderModel>)GetValue(ItemSourceProperty);
            }
            set
            {
                SetValue(ItemSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(List<RaderModel>), typeof(RederUC));

        public void Drag()
        {
            if (ItemSource == null || ItemSource.Count == 0)
                return;

            mainCanvas.Children.Clear();
            P1.Points.Clear();
            P2.Points.Clear();
            P3.Points.Clear();
            P4.Points.Clear();
            P5.Points.Clear();

            //调整grid大小
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            LayGrid.Width = size;
            LayGrid.Height = size;

            //半径
            double radius = size / 2;

            //中心点到各个点的角度
            double step = 360.0 / ItemSource.Count;

            for (int i = 0; i < ItemSource.Count; i++)
            {
                double x = (radius - 20) * Math.Cos((step * i - 90) * Math.PI / 180);
                double y = (radius - 20) * Math.Sin((step * i - 90) * Math.PI / 180);

                P1.Points.Add(new Point(radius + x, radius + y));
                P2.Points.Add(new Point(radius + x * 0.75, radius + y * 0.75));
                P3.Points.Add(new Point(radius + x * 0.5, radius + y * 0.5));
                P4.Points.Add(new Point(radius + x * 0.25, radius + y * 0.25));

                P5.Points.Add(new Point(radius + x * ItemSource[i].Value * 0.01, radius + y * ItemSource[i].Value * 0.01));

                TextBlock textBlock = new TextBlock();
                textBlock.Width = 60;
                textBlock.Text = ItemSource[i].ItemName;
                textBlock.FontSize = 10;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                textBlock.SetValue(Canvas.LeftProperty, radius + x - 30);
                textBlock.SetValue(Canvas.TopProperty, radius + y - 10);

                mainCanvas.Children.Add(textBlock);
            }
        }
    }
}
