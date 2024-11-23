using ProductMonitor.Models;
using ProductMonitor.UserControls;
using ProductMonitor.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProductMonitor.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            EnvironmentModels = new ObservableCollection<EnvironmentModel>
            {
                new EnvironmentModel{EnvItemName="光照(Lux)",EnvItemValue=123},
                new EnvironmentModel{EnvItemName="噪音(db)",EnvItemValue=55},
                new EnvironmentModel{EnvItemName="温度(℃)",EnvItemValue=80},
                new EnvironmentModel{EnvItemName="湿度(%)",EnvItemValue=43},
                new EnvironmentModel{EnvItemName="PM2.5(m)",EnvItemValue=20},
                new EnvironmentModel{EnvItemName="硫化氢(PPM)",EnvItemValue=15},
                new EnvironmentModel{EnvItemName="氮气(PPM)",EnvItemValue=18},
            };
            AlarmModels = new ObservableCollection<AlarmModel>
            {
                new AlarmModel{Number="01",Message="设备温度过高",Time="2024-11-01 18:48:56",Duration=7},
                new AlarmModel{Number="02",Message="车间温度过高",Time="2024-11-02 12:29:41",Duration=10},
                new AlarmModel{Number="03",Message="设备转速过快",Time="2024-11-03 09:24:21",Duration=12},
                new AlarmModel{Number="04",Message="设备气压过低",Time="2024-11-04 11:01:29",Duration=90},
            };
            DeviceModels = new ObservableCollection<DeviceModel>
            {
                new DeviceModel{DeviceItem="电能(Kw.h)",DeviceValue=60.8},
                new DeviceModel{DeviceItem="电压(V)",DeviceValue=390},
                new DeviceModel{DeviceItem="电流(A)",DeviceValue=5},
                new DeviceModel{DeviceItem="压差(kpa)",DeviceValue=13},
                new DeviceModel{DeviceItem="温度(℃)",DeviceValue=36},
                new DeviceModel{DeviceItem="振动(mm/s)",DeviceValue=4.1},
                new DeviceModel{DeviceItem="转速(r/min)",DeviceValue=2600},
                new DeviceModel{DeviceItem="气压(kpa)",DeviceValue=0.5},
            };
            RaderModels = new List<RaderModel>
            {
                new RaderModel{ItemName="排油烟机",Value=90},
                new RaderModel{ItemName="客梯",Value=30},
                new RaderModel{ItemName="供水机",Value=34.89},
                new RaderModel{ItemName="喷淋水泵",Value=69.59},
                new RaderModel{ItemName="稳压设备",Value=20},
            };
            StuffOutWorkModels = new ObservableCollection<StuffOutWorkModel>
            {
                new StuffOutWorkModel{StuffName="张晓婷",Position="技术员",OutWorkCount=123},
                new StuffOutWorkModel{StuffName="李晓",Position="操作员",OutWorkCount=23},
                new StuffOutWorkModel{StuffName="王克俭",Position="技术员",OutWorkCount=134},
                new StuffOutWorkModel{StuffName="陈佳栋",Position="统计员",OutWorkCount=143},
                new StuffOutWorkModel{StuffName="杨过",Position="技术员",OutWorkCount=12},
            };
            WorkShopModels = new ObservableCollection<WorkShopModel>
            {
                new WorkShopModel{WorkShopName="贴片车间",WorkingCount=32,WaitCount=8,WrongCount=4,StopCount=0},
                new WorkShopModel{WorkShopName="封装车间",WorkingCount=20,WaitCount=8,WrongCount=4,StopCount=0},
                new WorkShopModel{WorkShopName="焊接车间",WorkingCount=30,WaitCount=10,WrongCount=1,StopCount=10},
                new WorkShopModel{WorkShopName="贴片车间",WorkingCount=68,WaitCount=8,WrongCount=4,StopCount=0},
            };
            MachineModels = new ObservableCollection<MachineModel>();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int plan = random.Next(100, 1000);
                int complate = random.Next(0, plan);
                MachineModels.Add(new MachineModel
                {
                    MachineName = "焊接机-" + (i + 1),
                    FinishedCount = complate,
                    PlanCount = plan,
                    Status = "作业中",
                    OrderNo = "H20241112000" + i
                });
            }
        }
        private UserControl _monitorUC;

        public UserControl MonitorUC
        {
            get
            {
                if (_monitorUC == null)
                    _monitorUC = new MonitorUC();
                return _monitorUC;
            }
            set { _monitorUC = value; OnPropertyChanged(); }
        }

        #region 计数
        /// <summary>
        /// 机台总数
        /// </summary>
        private string _machineCount = "0298";

        /// <summary>
        /// 机台总数
        /// </summary>
        public string MachineCount
        {
            get { return _machineCount; }
            set { _machineCount = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 生产计数
        /// </summary>
        private string _productCount = "1689";

        /// <summary>
        /// 生产计数
        /// </summary>
        public string ProductCount
        {
            get { return _productCount; }
            set { _productCount = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 不良计数
        /// </summary>
        private string _badCount = "0023";

        /// <summary>
        /// 不良计数
        /// </summary>
        public string BadCount
        {
            get { return _badCount; }
            set { _badCount = value; OnPropertyChanged(); }
        }
        #endregion

        public ObservableCollection<EnvironmentModel> EnvironmentModels { get; set; }
        public ObservableCollection<AlarmModel> AlarmModels { get; set; }
        public ObservableCollection<DeviceModel> DeviceModels { get; set; }
        public List<RaderModel> RaderModels { get; set; }
        public ObservableCollection<StuffOutWorkModel> StuffOutWorkModels { get; set; }
        public ObservableCollection<WorkShopModel> WorkShopModels { get; set; }
        public ObservableCollection<MachineModel> MachineModels { get; set; }
    }
}
