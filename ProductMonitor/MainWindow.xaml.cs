using ProductMonitor.UserControls;
using ProductMonitor.ViewModels;
using ProductMonitor.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// 放大/缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWindowState_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        /// <summary>
        /// 小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 车间详情
        /// </summary>
        public ObservableCommand ShowDetail => new ObservableCommand(ShowDetailUserControl);
        void ShowDetailUserControl()
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                WorkShopDetailUC workShopDetailUC = new WorkShopDetailUC();
                viewModel.MonitorUC = workShopDetailUC;

                //动画效果(由下向上)
                //线条动画
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0, 50, 0, -50),
                                                                                new Thickness(0, 0, 0, 0),
                                                                                    new Duration(TimeSpan.FromSeconds(0.4)));
                //透明度
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.4)));

                Storyboard.SetTarget(thicknessAnimation, workShopDetailUC);
                Storyboard.SetTarget(doubleAnimation, workShopDetailUC);

                Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(thicknessAnimation);
                storyboard.Children.Add(doubleAnimation);
                storyboard.Begin();
            }
        }

        /// <summary>
        /// 返回主页
        /// </summary>
        public ObservableCommand GoBack => new ObservableCommand(GoBackMonitor);
        void GoBackMonitor()
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                WorkShopDetailUC workShopDetailUC = viewModel.MonitorUC as WorkShopDetailUC;
                //动画效果(由下向上)
                //线条动画
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0, 0, 0, 0),
                                                                                new Thickness(0, 50, 0, -50),
                                                                                    new Duration(TimeSpan.FromSeconds(0.4)));
                //透明度
                DoubleAnimation doubleAnimation = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.4)));

                Storyboard.SetTarget(thicknessAnimation, workShopDetailUC);
                Storyboard.SetTarget(doubleAnimation, workShopDetailUC);

                Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(thicknessAnimation);
                storyboard.Children.Add(doubleAnimation);

                storyboard.Completed += (se, ev) =>
                {
                    MonitorUC monitorUC = new MonitorUC();
                    viewModel.MonitorUC = monitorUC;
                };

                storyboard.Begin();
            }
        }
    }
}
