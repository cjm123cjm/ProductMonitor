namespace ProductMonitor.Models
{
    public class StuffOutWorkModel
    {
        /// <summary>
        /// 员工名称
        /// </summary>
        public string StuffName { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 缺岗次数
        /// </summary>
        public int OutWorkCount { get; set; }


        /// <summary>
        /// 界面显示宽度
        /// </summary>
        public int ShowWidth => OutWorkCount * 40 / 100;
    }
}
