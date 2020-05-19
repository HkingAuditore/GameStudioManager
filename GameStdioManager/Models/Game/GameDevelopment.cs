using System.Collections.Generic;
using System.Diagnostics;
using GameStdioManager.Models.Checkpoint;

namespace GameStdioManager.Models.Game
{
    public partial class Game : SimulatorBase
    {

        /************************************************************************/
        /*                检查点相关，需要在检查点调用的方法务必使用Static              */
        /************************************************************************/

        #region 开发

        /// <summary>
        ///     开发者
        /// </summary>
        private List<Staff.Staff> _developers = new List<Staff.Staff>();

        /// <summary>
        /// 默认开发时间
        /// </summary>
        private static int _developingTime = 800;

        /// <summary>
        ///     开始开发
        /// </summary>
        /// <param name="hours">开发时长</param>
        /// <param name="staff">开发人员</param>
        public void StartDevelop(int hours, int speed)
        {
            var arg = new CheckpointArgs();
            arg.CheckParm = hours;
            arg.UpdateParm = 0;
            arg.UpdateSpeed = speed;

            var cp = new Checkpoint.Checkpoint(0,
                                               SimulatorTimer.GetTimeAfterHours(hours),
                                               new[] { "EndDevelop" },
                                               new[] { "UpdateDevelop" },
                                               "CheckTimeAndProcess",
                                               this,
                                               arg,
                                               GetTypeName()
                                              );
            SimulatorTimer.AddCheckpoint(cp);
        }

        /// <summary>
        ///     开发更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void UpdateDevelop(SimulatorBase sender, CheckpointArgs args)
        {
            var game = (Game)sender;

            Debug.WriteLine(game.GameName + " Processing:" + args.UpdateParm + "%. In " + SimulatorTimer.GameTimeNow);
            args.UpdateParm += args.UpdateSpeed;
        }

        /// <summary>
        ///     开发结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void EndDevelop(SimulatorBase sender, CheckpointArgs args)
        {
            var game = (Game)sender;
            Debug.WriteLine(game.GameName + " Game FINISHED!");
        }

        #endregion 开发



    }
}