using System.Collections.Generic;
using System.Diagnostics;
using GameStdioManager.Controllers;
using GameStdioManager.Controllers.Game;
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
        public List<Staff.Staff> Developers = new List<Staff.Staff>();

        private float _developmentProcess = 0f;

        /// <summary>
        /// 默认开发时间
        /// </summary>
        // private static int _developingTime = 800;

        /// <summary>
        ///     开始开发
        /// </summary>
        /// <param name="hours">开发时长</param>
        /// <param name="staff">开发人员</param>
        public void StartDevelop(int hours)
        {
            var arg = new CheckpointArgs();
            arg.CheckParm = hours;
            arg.UpdateParm = 0f;
            arg.UpdateSpeed = 100f/(hours*3);
            ControllerBase.InsertInfoSql(this);

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

        #region 更新

        /// <summary>
        ///     开发更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void UpdateDevelop(SimulatorBase sender, CheckpointArgs args)
        {
            var game = (Game)sender;
            game._developmentProcess = args.UpdateParm;
            Debug.WriteLine(game.GameName + " Processing:" + args.UpdateParm + "%. In " + SimulatorTimer.GameTimeNow);
            args.UpdateParm += args.UpdateSpeed;
            UpdateDevelopEvent?.Invoke(sender, args);
        }

        /// <summary>
        /// 更新事件
        /// </summary>
        public static event CheckpointHandler UpdateDevelopEvent;

        public float GetGameDevelopProcess() => _developmentProcess;
        #endregion

        #region 结束
        
        /// <summary>
        ///     开发结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void EndDevelop(SimulatorBase sender, CheckpointArgs args)
        {
            var game = (Game)sender;
            game.GameIsDeveloping = false;
            game.GameFinishDevelopTime = SimulatorTimer.GameTimeNow;

            GameSQLController.UpdateGameInfoSql(GameSQLController.ReadGameInfoSql(game.GameNumber), game);
            Debug.WriteLine(game.GameName + " Game FINISHED!");
            EndDevelopEvent?.Invoke(sender, args);
        }

        /// <summary>
        /// 结束事件
        /// </summary>
        public static event CheckpointHandler EndDevelopEvent;

        #endregion


        #region 开发人员

        /// <summary>
        /// 新增开发人员
        /// </summary>
        /// <param name="developer"></param>
        public void AddDeveloper(Staff.Staff developer)
        {
            Developers.Add(developer);
            GameDevelopmentRelationSqlController.InsertDeveloperRelation(this,developer);
        }

        /// <summary>
        /// 移除开发人员
        /// </summary>
        /// <param name="developer"></param>
        public void RemoveDeveloper(Staff.Staff developer)
        {
            Developers.Remove(developer);
            GameDevelopmentRelationSqlController.DeleteDeveloperRelation(this, developer);

        }

        #endregion


        #endregion 开发



    }
}