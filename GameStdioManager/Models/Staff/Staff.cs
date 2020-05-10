using System;

namespace GameStdioManager.Models.Staff
{

    #region 枚举

    [Flags]
    public enum Gender : uint
    {
        Male = 0x01,
        Female = 0x02
    }

    [Flags]
    public enum Rank : uint
    {
        /// 实习生
        Trainee = 0x01,
        /// 初级
        Junior = 0x02,
        /// 中级
        Intermediate = 0x04,
        /// 高级
        Senior = 0x08,
        /// 资深
        Professional = 0x16,
        /// 专家
        Expert = 0x32,
        /// 行业领袖
        Leader = 0x64
    }

    [Flags]
    public enum Occupation : uint
    {
        /// 制作人
        Producer = 0x01,
        /// 策划
        Designer = 0x02,
        /// 美术
        Artist = 0x04,
        /// 程序
        Programmer = 0x08,
        /// 音乐
        Musicians = 0x16,
    }
    

    #endregion

    public class Staff
    {
        /// <summary>
        /// 员工工号
        /// </summary>
        public string StaffNumber { get; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName { get; }

        /// <summary>
        /// 员工性别
        /// </summary>
        public Gender StaffGender { get; }

        /// <summary>
        /// 员工薪水
        /// </summary>
        public int StaffSalary { get; set; }

        /// <summary>
        /// 员工职称
        /// </summary>
        public Rank StaffRank { get; set; }

        /// <summary>
        /// 员工职业
        /// </summary>
        public Occupation StaffOccupation { get; set; }

        #region 能力点数

        /// <summary>
        /// 体力
        /// </summary>
        public int StaffStrength { get; set; }

        /// <summary>
        /// 智力
        /// </summary>
        public int StaffIntelligence { get; set; }

        /// <summary>
        /// 责任心
        /// </summary>
        public int StaffConscientiousness { get; set; }

        /// <summary>
        /// 叛逆性
        /// </summary>
        public int StaffRebelliousness { get; set; }

        #endregion

        /// <summary>
        /// 员工财产
        /// </summary>
        public int StaffProperty { get; }

        public int Staff
    }
}