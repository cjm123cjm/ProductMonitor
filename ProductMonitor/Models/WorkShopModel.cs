namespace ProductMonitor.Models
{
    /// <summary>
    /// 车间模型
    /// </summary>
    public class WorkShopModel
    {
        /// <summary>
        /// 车间名称
        /// </summary>
        public string WorkShopName { get; set; }

        /// <summary>
        /// 作业数量
        /// </summary>
        public int WorkingCount { get; set; }

        /// <summary>
        /// 等待数量
        /// </summary>
        public int WaitCount { get; set; }

        /// <summary>
        /// 故障数量
        /// </summary>
        public int WrongCount { get; set; }

        /// <summary>
        /// 等待数量
        /// </summary>
        public int StopCount { get; set; }

        public int TotalCount => WorkingCount + WaitCount + WrongCount + StopCount;
    }
}
