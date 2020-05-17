using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameStdioManager.Models.Checkpoint;

namespace GameStdioManager.Models.Game
{
    [Flags]
    public enum Genres : uint
    {
        /// 模拟
        SIM = 0x01,

        /// 动作
        ACT = 0x02,

        /// 策略经营
        SLG = 0x04,

        /// 角色扮演
        RPG = 0x08,

        /// 冒险
        AVG = 0x10,

        /// 体育
        SPG = 0x20,

        /// 射击
        STG = 0x40,

        /// 即时战略
        RTS = 0x40,

        /// Galgame
        GAL = 0x80,

    }

    public class Game : SimulatorBase
    {
        #region 基本属性

        /// <summary>
        ///     游戏编号
        /// </summary>
        public string GameNumber { get; }

        /// <summary>
        ///     游戏名称
        /// </summary>
        public string GameName { get; }

        /// <summary>
        ///     游戏价格
        /// </summary>
        public int GamePrice { get; set; }

        /// <summary>
        ///     游戏趣味评分
        /// </summary>
        public int GameFun { get; set; }

        /// <summary>
        ///     游戏美术
        /// </summary>
        public int GameArt { get; set; }

        /// <summary>
        ///     游戏音乐
        /// </summary>
        public int GameMusic { get; set; }


        /// <summary>
        ///     游戏销量
        /// </summary>
        public int GameSales { get; set; }

        /// <summary>
        ///     制作工作室编号
        /// </summary>
        public string GameStudio { get; }

        /// <summary>
        /// 游戏类型
        /// </summary>
        public Genres GameGenres { get; }

        #endregion

        #region 构造函数

        public Game(string gameNumber, string gameName,   int    gamePrice, int gameFun, int gameArt, int gameMusic,
                    int    gameSales,  string gameStudio, Genres gameGenres)
        {
            GameNumber = gameNumber;
            GameName   = gameName;
            GamePrice  = gamePrice;
            GameFun    = gameFun;
            GameArt    = gameArt;
            GameMusic  = gameMusic;
            GameSales  = gameSales;
            GameStudio = gameStudio;
            GameGenres = gameGenres;
        }

        public Game(string gameNumber, string gameName)
        {
            GameNumber = gameNumber;
            GameName = gameName;
        }

        #endregion

        #region 逻辑

        #region 开发

        /// <summary>
        /// 开发者
        /// </summary>
        private List<Staff.Staff> developers = new List<Staff.Staff>();

        /// <summary>
        /// 开始开发
        /// </summary>
        /// <param name="hours">开发时长</param>
        /// <param name="staff">开发人员</param>
        public void StartDevelop(int hours,int speed)
        {
            var arg = new CheckpointArgs();
            arg.CheckParm = hours;
            arg.UpdateParm = 0;

            var cp = new Checkpoint.Checkpoint(0, 
                                               SimulatorTimer.GetTimeAfterHours(hours),
                                               this,
                                               arg
                                              );

            cp.SetCheckMethod((sender, args) =>
                              {
                                  return (args.UpdateParm >= 100 || SimulatorTimer.GameTimeNow >= cp.CheckpointTime);
                              });
            cp.AddUpdateProcess((sender,args) =>
                                {
                                    Debug.WriteLine(this.GameName + " Processing:" + args.UpdateParm +"%");
                                    args.UpdateParm += speed;
                                });

            SimulatorTimer.AddCheckpoint(cp);

            cp.AddCheckProcess((sender, args) => Debug.WriteLine(this.GameName +" Game FINISHED!"));
            cp.AddCheckProcess(EndDevelop);

        }

        /// <summary>
        /// 开发结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void EndDevelop(object sender,CheckpointArgs args)
        {
            Game game = (Game) sender;
            Debug.WriteLine(game.GameName);
        }

        #endregion

        #endregion
    }
}