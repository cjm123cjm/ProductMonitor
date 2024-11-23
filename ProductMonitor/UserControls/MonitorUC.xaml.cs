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
using System.Windows.Threading;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// MonitorUC.xaml 的交互逻辑
    /// </summary>
    public partial class MonitorUC : UserControl
    {
        string[] str = new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        public MonitorUC()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1),
                IsEnabled = true
            };
            timer.Tick += (o, s) =>
            {
                txtTimeStr.Text = DateTime.Now.ToString("HH:mm");
                txtDateStr.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtWeekStr.Text = str[(int)DateTime.Now.DayOfWeek];
            };
            timer.Start();
        }
    }
}
