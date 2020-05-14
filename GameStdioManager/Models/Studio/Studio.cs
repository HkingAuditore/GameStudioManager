namespace GameStdioManager.Models.Studio
{
    public class Studio: SimulatorBase
    {

        /// <summary>
        /// 工作室编号
        /// </summary>
        public string StudioNumber { get; }
        /// <summary>
        /// 工作室名称
        /// </summary>
        public string StudioName { get; }
        /// <summary>
        /// 工作室财产
        /// </summary>
        public int StudioProperty { get; set; }
        /// <summary>
        /// 工作室声誉
        /// </summary>
        public int StudioReputation { get; set; }


        public Studio(string studioNumber, string studioName, int studioProperty, int studioReputation)
        {
            StudioNumber = studioNumber;
            StudioName = studioName;
            StudioProperty = studioProperty;
            StudioReputation = studioReputation;
        }

        #region 类基本操作



        #endregion


    }
}