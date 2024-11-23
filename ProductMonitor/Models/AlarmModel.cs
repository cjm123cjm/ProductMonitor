namespace ProductMonitor.Models
{
    public class AlarmModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 报警信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 报警时长 单位：秒
        /// </summary>
        public int Duration { get; set; }
    }
}
