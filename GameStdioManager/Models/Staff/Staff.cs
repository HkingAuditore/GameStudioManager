using System;
using System.Collections.Generic;
using System.Text;

namespace GameStdioManager.Models.Staff
{
    #region 枚举

    public enum Gender
    {
        Male,
        Female
    }

    public enum Rank
    {
        /// 实习生
        Trainee,

        /// 初级
        Junior,

        /// 中级
        Intermediate,

        /// 高级
        Senior,

        /// 资深
        Professional,

        /// 专家
        Expert,

        /// 行业领袖
        Leader
    }

    public enum Occupation
    {
        /// 制作人
        Producer,

        /// 策划
        Designer,

        /// 美术
        Artist,

        /// 程序
        Programmer,

        /// 音乐
        Musicians
    }

    [Flags]
    public enum Temperament : uint
    {
        /// 友善
        Friendly = 0x01,

        /// 无主见
        Indecisive = 0x02,

        /// 有天赋
        Gifted = 0x04,

        /// 坏心肠
        Malevolent = 0x08,

        /// 领袖气质
        Charisma = 0x10
    }

    #endregion

    public class Staff
    {
        #region 员工属性

        /// <summary>
        ///     员工工号
        /// </summary>
        public string StaffNumber { get; }

        /// <summary>
        ///     员工姓名
        /// </summary>
        public string StaffName { get; }

        /// <summary>
        ///     员工性别
        /// </summary>
        public Gender StaffGender { get; }

        /// <summary>
        ///     员工薪水
        /// </summary>
        public int StaffSalary { get; set; }

        /// <summary>
        ///     员工职称
        /// </summary>
        public Rank StaffRank { get; set; }

        /// <summary>
        ///     员工职业
        /// </summary>
        public Occupation StaffOccupation { get; set; }

        #region 能力点数

        /// <summary>
        ///     体力
        /// </summary>
        public int StaffStrength { get; set; }

        /// <summary>
        ///     智力
        /// </summary>
        public int StaffIntelligence { get; set; }

        /// <summary>
        ///     忠诚
        /// </summary>
        public int StaffLoyalty { get; set; }

        #endregion

        /// <summary>
        ///     员工财产
        /// </summary>
        public int StaffProperty { get; }


        /// <summary>
        ///     上班时间
        /// </summary>
        public int TimeToWork { get; set; }

        /// <summary>
        ///     下班时间
        /// </summary>
        public int TimeToQuit { get; set; }

        /// <summary>
        ///     工作日长度
        /// </summary>
        public int WeekdaysLength { get; set; }


        /// <summary>
        ///     员工性格
        /// </summary>
        public Temperament StaffTemperament { get; }

        /// <summary>
        ///     员工关系
        /// </summary>
        public Dictionary<string, int> StaffRelationship = new Dictionary<string, int>();

        /// <summary>
        ///     员工所在公司
        /// </summary>
        public string StaffStudio { get; set; }

        #endregion


        public Staff(string     staffNumber,     string staffName, Gender staffGender,
                     int        staffSalary,     Rank   staffRank,
                     Occupation staffOccupation, int    staffStrength, int staffIntelligence,
                     int        staffLoyalty,
                     int        staffProperty,  Temperament staffTemperament, int timeToWork, int timeToQuit,
                     int        weekdaysLength, string      staffStudio)
        {
            StaffNumber       = staffNumber;
            StaffName         = staffName;
            StaffGender       = staffGender;
            StaffSalary       = staffSalary;
            StaffRank         = staffRank;
            StaffOccupation   = staffOccupation;
            StaffStrength     = staffStrength;
            StaffIntelligence = staffIntelligence;
            StaffLoyalty      = staffLoyalty;
            StaffProperty     = staffProperty;
            StaffTemperament  = staffTemperament;
            TimeToWork        = timeToWork;
            TimeToQuit        = timeToQuit;
            WeekdaysLength    = weekdaysLength;
            StaffStudio       = staffStudio;
        }


        #region 基本类型操作

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("编号："      + StaffNumber        + ",");
            result.Append("姓名："      + StaffName          + ",");
            result.Append("性别："      + StaffGender        + ",");
            result.Append("薪水："      + StaffSalary        + ",");
            result.Append("职称："      + StaffRank          + ",");
            result.Append("职务："      + StaffOccupation    + ",");
            result.Append("体力："      + StaffStrength      + ",");
            result.Append("智力："      + StaffIntelligence  + ",");
            result.Append("忠诚："      + StaffLoyalty       + ",");
            result.Append("财产："      + StaffProperty      + ",");
            result.Append("上班时间："   + TimeToWork         + ",");
            result.Append("下班时间："   + TimeToQuit         + ",");
            result.Append("工作日长度："  + WeekdaysLength    + ",");
            result.Append("性格："       + StaffTemperament  + ",");
            result.Append("所在工作室："  + StaffStudio       + ",");
            return result.ToString();
        }

        public object GetPropertyValue(string propertyName)
        {
            return GetType().GetProperty(propertyName)?.GetValue(this, null);
        }

        #endregion
    }
}