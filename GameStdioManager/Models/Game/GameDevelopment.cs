using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameStdioManager.Controllers;
using GameStdioManager.Controllers.Game;
using GameStdioManager.Models.Checkpoint;
using GameStdioManager.Models.Staff;

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
        /// <param name="studio">开发工作室</param>
        public void StartDevelop(int hours)
        {
            var arg = new CheckpointArgs();
            arg.CheckParm = hours;
            arg.UpdateParm = 0f;
            arg.UpdateSpeed = 100f/(hours*3);
            arg.CheckTime = SimulatorTimer.GetTimeAfterHours(hours);
            ControllerBase.InsertInfoSql(this);
            this.GameStudioObject.AddDevelopingGame(this);

            var cp = new Checkpoint.Checkpoint(this.GameNumber,
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


        #region 判定

        public static bool CheckTimeAndProcess(object sender, CheckpointArgs args) =>
            args.UpdateParm >= 100 || SimulatorTimer.GameTimeNow >= args.CheckTime;


        #endregion


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

            float artCapability = (from developer in game.Developers
                                 where developer.IsWorking && developer.StaffOccupation == Occupation.Artist
                                 select developer.StaffIntelligence).Aggregate(0, (current, s)
                                                                                     => current + s)/100f;

            float musicCapability = (from developer in game.Developers
                                     where developer.IsWorking && developer.StaffOccupation == Occupation.Musician
                                     select developer.StaffIntelligence).Aggregate(0, (current, s)
                                                                                          => current + s)/100f;

            float funCapability = (from developer in game.Developers
                                   where developer.IsWorking && developer.StaffOccupation == Occupation.Designer
                                   select developer.StaffIntelligence).Aggregate(0, (current, s)
                                                                                        => current + s)/100f;

            float programCapability = (from developer in game.Developers
                                       where developer.IsWorking && developer.StaffOccupation == Occupation.Programmer
                                       select developer.StaffIntelligence).Aggregate(0, (current, s)
                                                                                            => current + s)/100f;

            float controlCapability = (from developer in game.Developers
                                       where developer.IsWorking && developer.StaffOccupation == Occupation.Producer
                                       select developer.StaffIntelligence).Aggregate(0, (current, s)
                                                                                            => current + s)/100f;


            game.GameArt = (int)(((float) game.GameArt) + artCapability * (1+controlCapability) * (1 + programCapability * 0.7));
            game.GameMusic = (int)(((float) game.GameMusic) + musicCapability * (1+controlCapability) * (1 + programCapability * 0.7));
            game.GameFun = (int)(((float)game.GameFun) + funCapability * (1+controlCapability) * (1 + programCapability * 0.7));

            args.ArtParm = game.GameArt;
            args.MusicParm = game.GameMusic;
            args.FunParm = game.GameFun;


            Debug.WriteLine(game.GameName + " Processing:" + args.UpdateParm + "%. In " + SimulatorTimer.GameTimeNow);
            Debug.WriteLine(game.GameName + " ArtParm:" + args.ArtParm + ". In " + SimulatorTimer.GameTimeNow);
            Debug.WriteLine(game.GameName + " GameArt:" + game.GameArt + ". In " + SimulatorTimer.GameTimeNow);
            Debug.WriteLine(game.GameName + " GameArt Temp:" + (int)(((float)game.GameFun + funCapability) * (1 + controlCapability) * (0.5f + programCapability)) + ". In " + SimulatorTimer.GameTimeNow);
            Debug.WriteLine(game.GameName + " GameArt Capability:" + artCapability + ". In " + SimulatorTimer.GameTimeNow);
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
            game.GameStudioObject.AddDevelopedGame(game);
            game.GameStudioObject.RemoveDevelopingGame(game);
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