using System;
using System.Diagnostics;
using System.Xml.Linq;
using GameStdioManager.Controllers.Staff;
using GameStdioManager.Models.Checkpoint;
using Microsoft.Ajax.Utilities;

namespace GameStdioManager.Models.Staff
{
    public partial class Staff
    {
        #region 员工属性

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

        public bool IsInWorkTime() =>
            IsWeekday() && SimulatorTimer.GameTimeNow.Hour >= TimeToWork &&
            SimulatorTimer.GameTimeNow.Hour                < TimeToQuit;

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
                                             new[] {"WorkUpdate"},
                                             "CheckStartWork",
                                             this,
                                             null,
                                             "Staff",
                                             true, false);
        }

        /// <summary>
        ///     上班
        /// </summary>
        public static void StartWork(SimulatorBase sender, CheckpointArgs args)
        {
            ((Staff) sender).IsWorking = true;
            StaffSQLController.CheckSql((Staff)sender,true);
            Debug.WriteLine(((Staff) sender).StaffName + "上班！");
            SimulatorTimer.SpeedSetNormal();
        }

        public static void WorkUpdate(SimulatorBase sender, CheckpointArgs args)
        {
            var staff                                                                 = (Staff) sender;
            if (staff.IsWorking && staff.StaffCurStrength > 0)
            {
                staff.StaffCurStrength -= 1 * SimulatorTimer.TimeSpeed;
                if (staff.StaffCurStrength < 0) staff.StaffCurStrength = 0;

            }
        }

        /// <summary>
        ///     查看是否上班
        /// </summary>
        public static bool CheckStartWork(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff) sender;
            // Debug.WriteLine(staff.StaffCurStrength);
            return !staff.IsWorking && staff.IsWeekday() && staff.StaffCurStrength > 10 &&
                   staff.IsInWorkTime();
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
                                             new[] {"QuitUpdate"},
                                             "CheckQuitWork",
                                             this,
                                             null,
                                             "Staff",
                                             true, false);
        }

        /// <summary>
        ///     下班
        /// </summary>
        public static void QuitWork(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff) sender;
            staff.IsWorking = false;
            StaffSQLController.CheckSql(staff, false);

            Debug.WriteLine(((Staff) sender).StaffName + "下班！");
            if (staff.StaffStudioObject.FindWorkingStaffs().Count == 0) SimulatorTimer.SpeedSetQuick();
        }

        public static void QuitUpdate(SimulatorBase sender, CheckpointArgs args)
        {
            var staff = (Staff) sender;
            if (!staff.IsWorking && staff.StaffCurStrength < staff.StaffStrength)
            {
                staff.StaffCurStrength += 1 * SimulatorTimer.TimeSpeed;
                if (staff.StaffCurStrength > staff.StaffStrength) staff.StaffCurStrength = staff.StaffStrength;
            }
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
                       staff.IsWeekday() && !staff.IsInWorkTime()
                   );
        }

        /// <summary>
        /// 将员工当前上班数据存储为XML
        /// </summary>
        /// <returns></returns>
        public XElement ConvertStaffCurWorkDataToXElement()
        {
            var root = new XElement("Staff",
                                    new XAttribute("StaffNumber",    this.StaffNumber),
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