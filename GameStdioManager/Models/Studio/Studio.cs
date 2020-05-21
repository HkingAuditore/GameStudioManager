using System.Collections.Generic;
using System.Linq;

namespace GameStdioManager.Models.Studio
{
    public class Studio : SimulatorBase
    {
        public Studio(string studioNumber, string studioName, int studioProperty, int studioReputation)
        {
            StudioNumber     = studioNumber;
            StudioName       = studioName;
            StudioProperty   = studioProperty;
            StudioReputation = studioReputation;
        }

        /// <summary>
        ///     工作室编号
        /// </summary>
        public string StudioNumber { get; }

        /// <summary>
        ///     工作室名称
        /// </summary>
        public string StudioName { get; }

        /// <summary>
        ///     工作室财产
        /// </summary>
        public int StudioProperty { get; set; }

        /// <summary>
        ///     工作室声誉
        /// </summary>
        public int StudioReputation { get; set; }


        #region 类基本操作

        #region 接口实现

        public override string GetObjectNumber() => StudioNumber;

        #endregion 接口实现


        #endregion 类基本操作

        #region 员工操作

        /// <summary>
        /// 员工
        /// </summary>
        public List<Staff.Staff> StudioStaffs = new List<Staff.Staff>();

        public void AddStaff(Staff.Staff staff) => StudioStaffs.Add(staff);

        public void RemoveStaff(Staff.Staff staff) => StudioStaffs.Remove(staff);

        /// <summary>
        /// 查找员工
        /// </summary>
        /// <param name="staffNumber"></param>
        /// <returns></returns>
        public Staff.Staff FindStaff(string staffNumber) => (from s in StudioStaffs
                                                             where s.StaffNumber == staffNumber
                                                             select s).First();

        #endregion
    }
}