using System;
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

        public void StartDevelop(int hours)
        {
            var arg = new CheckpointArgs(hours);
            var cp = new Checkpoint.Checkpoint(0, 
                                               SimulatorTimer.GetTimeAfterHours(hours), 
                                               "OnGameFinishDevelop", 
                                               arg,
                                               this
                                               );
            SimulatorTimer.TimeTable.Add(cp);
            CheckpointsProcessing.OnGameFinishDevelop += (sender, args) => Debug.WriteLine(this.GameNumber +" Game ends in " + args.Parm +" hours.");
            CheckpointsProcessing.OnGameFinishDevelop += EndDevelop;
        }

        public void EndDevelop(object sender,CheckpointArgs args)
        {
            Game game = (Game) sender;
            Debug.WriteLine(game.GameName);
        }

        #endregion

        #endregion
    }
}