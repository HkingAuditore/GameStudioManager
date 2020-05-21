using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameStdioManager.Controllers.Game;
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
        GAL = 0x80
    }

    public partial class Game : SimulatorBase
    {
        #region 接口实现

        public override string GetObjectNumber() => GameNumber;

        #endregion 接口实现

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
        ///     游戏类型
        /// </summary>
        public Genres GameGenres { get; }

        /// <summary>
        ///     游戏是否正在开发中
        /// </summary>
        public bool GameIsDeveloping { get; set; }

        /// <summary>
        ///     游戏开发完毕时间
        /// </summary>
        public DateTime GameFinishDevelopTime { get; set; }

        /// <summary>
        ///     游戏开发开始时间
        /// </summary>
        public DateTime GameStartDevelopTime { get; set; }

        public Studio.Studio GameStudioObject;

        #endregion 基本属性

        #region 构造函数

        public Game(string gameNumber, string gameName,   int    gamePrice,  int  gameFun, int gameArt, int gameMusic,
                    int    gameSales,  string gameStudio, Genres gameGenres, bool gameIsDeveloping)
        {
            GameNumber       = gameNumber;
            GameName         = gameName;
            GamePrice        = gamePrice;
            GameFun          = gameFun;
            GameArt          = gameArt;
            GameMusic        = gameMusic;
            GameSales        = gameSales;
            GameStudio       = gameStudio;
            GameGenres       = gameGenres;
            GameIsDeveloping = gameIsDeveloping;
        }

        /// <summary>
        /// 在开发游戏时使用的构造函数
        /// </summary>
        /// <param name="gameNumber"></param>
        /// <param name="gameName"></param>
        public Game(string gameNumber, string gameName,string gameStudio)
        {
            GameNumber = gameNumber;
            GameName   = gameName;
            GameStudio = gameStudio;
            GameStartDevelopTime = SimulatorTimer.GameTimeNow;
            GameIsDeveloping = true;
        }

        #endregion 构造函数

        #region 逻辑

        /// <summary>
        /// 向SQL更新实例
        /// </summary>
        public void UpdateSql() =>
            GameSQLController.UpdateGameInfoSql(GameSQLController.ReadGameInfoSql(this.GameNumber),this);

        #endregion 逻辑
    }
}