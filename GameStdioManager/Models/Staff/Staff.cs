using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models.Checkpoint;

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
        Musician
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

    #endregion 枚举

    public class Staff : SimulatorBase
    {
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
            IsWorking         = false;
            StaffCurStrength = staffStrength;
        }

        #region 基本类型操作

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("编号：" + StaffNumber       + ",");
            result.Append("姓名：" + StaffName         + ",");
            result.Append("性别：" + StaffGender       + ",");
            result.Append("薪水：" + StaffSalary       + ",");
            result.Append("职称：" + StaffRank         + ",");
            result.Append("职务：" + StaffOccupation   + ",");
            result.Append("体力：" + StaffStrength     + ",");
            result.Append("智力：" + StaffIntelligence + ",");
            result.Append("忠诚：" + StaffLoyalty      + ",");
            result.Append("财产：" + StaffProperty     + ",");
            result.Append("上班时间：" + TimeToWork      + ",");
            result.Append("下班时间：" + TimeToQuit      + ",");
            result.Append("工作日长度：" + WeekdaysLength + ",");
            result.Append("性格：" + StaffTemperament  + ",");
            result.Append("所在工作室：" + StaffStudio    + ",");
            return result.ToString();
        }

        #endregion 基本类型操作

        #region 接口实现

        public override string GetObjectNumber() => StaffNumber;

        #endregion 接口实现

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

        #endregion 能力点数

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

        /// <summary>
        ///     员工所在公司实例
        /// </summary>
        public Studio.Studio StaffStudioObject;

        /// <summary>
        /// 员工当前体力值
        /// </summary>
        public int StaffCurStrength;

        /// <summary>
        ///     正在工作
        /// </summary>
        public bool IsWorking;

        #endregion 员工属性


        #region 逻辑

        /// <summary>
        ///     向数据库更新员工数据
        /// </summary>
        public void UpdateSql()
        {
            StaffSQLController.UpdateStaffInfoSql(StaffSQLController.ReadStaffInfoSql(StaffNumber), this);
        }

        #region 上下班控制

        private Checkpoint.Checkpoint _staffStartWorkCheckpoint;

        private Checkpoint.Checkpoint _staffQuitWorkCheckpoint;

        /// <summary>
        /// 生成员工的工作检查点
        /// </summary>
        public void GenerateWorkCheckpoints()
        {
            _staffStartWorkCheckpoint = GetStartWorkCheckpoint();
            _staffQuitWorkCheckpoint  = GetQuitWorkCheckpoint();
            SimulatorTimer.AddCheckpoint(_staffStartWorkCheckpoint);
            SimulatorTimer.AddCheckpoint(_staffQuitWorkCheckpoint);
        }

        /// <summary>
        /// 移除员工的工作检查点
        /// </summary>
        public void RemoveWorkCheckpoints()
        {
            SimulatorTimer.RemoveCheckpoint(_staffStartWorkCheckpoint);
            SimulatorTimer.RemoveCheckpoint(_staffQuitWorkCheckpoint);
        }

        //
        // public void ChangeWorkTime(int timeToWork)
        // {
        //     this.TimeToWork = timeToWork;
        //     this._staffStartWorkCheckpoint.
        // }
        //
        // public void ChangeQuitTime(int timeToQuit)
        // {
        //     this.TimeToQuit = timeToQuit;
        //
        // }

        public bool IsInWorkTime() =>
            IsWeekday() && SimulatorTimer.GameTimeNow.Hour >= TimeToWork &&
            SimulatorTimer.GameTimeNow.Hour  < TimeToQuit;

        #region 上班

        private Checkpoint.Checkpoint GetStartWorkCheckpoint()
        {
            var dt = new DateTime(SimulatorTimer.GameTimeNow.Year,
                                  SimulatorTimer.GameTimeNow.Month,
                                  SimulatorTimer.GameTimeNow.Day,
                                  TimeToWork,
                                  0,
                                  0
                                 );
            return new Checkpoint.Checkpoint(StaffNumber,
                                             dt,
                                             new[] {"StartWork"},
                                             new []{"WorkUpdate"},
                                             "CheckStartWork",
                                             this,
                                             null,
                                             "Staff",
                                             true);
        }

        /// <summary>
        ///     上班
        /// </summary>
        public static void StartWork(SimulatorBase sender, CheckpointArgs args)
        {
            ((Staff) sender).IsWorking = true;
            Debug.WriteLine(((Staff) sender).StaffName + "上班！");
            SimulatorTimer.SpeedSetNormal();
        }

        public static void WorkUpdate(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff)sender;
            if (staff.IsWorking && staff.StaffCurStrength > 0) staff.StaffCurStrength -= 1 * SimulatorTimer.TimeSpeed;
            if (staff.StaffCurStrength < 0) staff.StaffCurStrength = 0;
        }

        /// <summary>
        ///     查看是否上班
        /// </summary>
        public static bool CheckStartWork(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff)sender;
            return !staff.IsWorking && staff.IsWeekday() && staff.StaffCurStrength > 10 &&
                   SimulatorTimer.GameTimeNow.Hour == staff.TimeToWork;
        }

        private bool IsWeekday()
        {
            var curDay                 = Convert.ToInt16(SimulatorTimer.GameTimeNow.DayOfWeek);
            if (curDay    == 0) curDay = 7;
            return curDay <= WeekdaysLength;
        }

        #endregion


        #region 下班

        private Checkpoint.Checkpoint GetQuitWorkCheckpoint()
        {
            var dt = new DateTime(SimulatorTimer.GameTimeNow.Year,
                                  SimulatorTimer.GameTimeNow.Month,
                                  SimulatorTimer.GameTimeNow.Day,
                                  TimeToQuit,
                                  0,
                                  0
                                 );
            return new Checkpoint.Checkpoint(StaffNumber,
                                             dt,
                                             new[] {"QuitWork"},
                                             new []{ "QuitUpdate" },
                                             "CheckQuitWork",
                                             this,
                                             null,
                                             "Staff",
                                             true);
        }

        /// <summary>
        ///     下班
        /// </summary>
        public static void QuitWork(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff) sender;
            staff.IsWorking = false;
            Debug.WriteLine(((Staff) sender).StaffName + "下班！");
            if (staff.StaffStudioObject.FindWorkingStaffs().Count == 0) SimulatorTimer.SpeedSetQuick();
        }

        public static void QuitUpdate(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff) sender;
            if (!staff.IsWorking && staff.StaffCurStrength < staff.StaffStrength) staff.StaffCurStrength += 1 * SimulatorTimer.TimeSpeed;
            if (staff.StaffCurStrength > staff.StaffStrength) staff.StaffCurStrength = staff.StaffStrength;

        }


        /// <summary>
        ///     查看是否下班
        /// </summary>
        public static bool CheckQuitWork(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff) sender;
            return staff.IsWorking
                 &&
                   (
                       staff.StaffCurStrength <= 0
                     ||
                       staff.IsWeekday() && SimulatorTimer.GameTimeNow.Hour == staff.TimeToQuit
                   );
        }

        /// <summary>
        /// 将员工当前上班数据存储为XML
        /// </summary>
        /// <returns></returns>
        public XElement ConvertStaffCurWorkDataToXElement()
        {
            var root = new XElement("Staff",
                                    new XAttribute("StaffNumber", this.StaffNumber),
                                    new XAttribute("StaffIsWorking", this.IsWorking),
                                    new XElement("StaffCurStrength", this.StaffCurStrength)
                                   );
            return root;
        }


        #endregion

        #endregion

        #endregion



    }
}