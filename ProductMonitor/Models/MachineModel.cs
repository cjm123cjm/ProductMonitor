namespace ProductMonitor.Models
{
    public class MachineModel
    {
        /// <summary>
        /// 机台名称
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 计划数量
        /// </summary>
        public int PlanCount { get; set; }
        /// <summary>
        /// 实际数量
        /// </summary>
        public int FinishedCount { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 完成百分比
        /// </summary>
        public double Percent => FinishedCount * 100.0 / PlanCount;
    }
}
