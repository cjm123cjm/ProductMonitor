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
using System.Windows.Shapes;

namespace ProductMonitor.Views
{
    /// <summary>
    /// SettingView.xaml 的交互逻辑
    /// </summary>
    public partial class SettingView : Window
    {
        public SettingView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 定位到相应的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            string tag = "";
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                tag = radioButton.Tag.ToString();
            }
            frame.Navigate(new Uri("pack://application:,,,/ProductMonitor;component/Views/SettingPage.xaml#" + tag), UriKind.RelativeOrAbsolute);
        }
    }
}
