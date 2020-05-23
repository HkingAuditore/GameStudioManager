using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;
using System.Web;
using System.Xml.Linq;
using GameStdioManager.Controllers.Player;
using GameStdioManager.Pages;
using Microsoft.Ajax.Utilities;

namespace GameStdioManager.Models
{
    public class SimulatorTimer
    {


        /// <summary>
        /// </summary>
        /// <param name="isReload">是否为重载游戏</param>
        public SimulatorTimer(bool isReload)
        {
            if (!isReload)
            {
                GameStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                                             DateTime.Now.Minute, 0);
                GameTimeNow = GameStartTime;
            }
            else
            {
                ReloadTimer();
            }

            _gameTimer = new Timer(1000);
        }

        #region 基本属性

        /// <summary>
        ///     游戏起始时间
        /// </summary>
        public static DateTime GameStartTime;

        /// <summary>
        ///     游戏世界当前时间
        /// </summary>
        public static DateTime GameTimeNow;

        /// <summary>
        ///     计时器
        /// </summary>
        private static Timer _gameTimer;

        /// <summary>
        /// 是否计时
        /// </summary>
        private static bool _isTick = true;

        #endregion 基本属性

        #region 纯时间操作

        /// <summary>
        ///     重载时间
        /// </summary>
        private void ReloadTimer()
        {
            GameTimeNow = PageBase.PagePlayer.PlayerNowTime;
        }

        /// <summary>
        ///     开始计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TimerUpdate(object sender, EventArgs e)
        {
            _gameTimer.AutoReset = true;
            // 每次时间步进的操作
            _gameTimer.Elapsed += (s, ea) => { GameTimeNow = GameTimeNow.AddMinutes(TimeSpeed * 20); };
            _gameTimer.Elapsed += Update;

            _gameTimer.Enabled = true;
            _gameTimer.Start();
        }

        /// <summary>
        ///     获取当前时间n个小时后的时间
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime GetTimeAfterHours(int n)
        {
            var temp = new DateTime(GameTimeNow.Year,
                                    GameTimeNow.Month,
                                    GameTimeNow.Day,
                                    GameTimeNow.Hour,
                                    GameTimeNow.Minute,
                                    GameTimeNow.Second);
            return temp.AddHours(n);
        }

        /// <summary>
        /// 时间暂停
        /// </summary>
        public static void Pause()
        {
            _isTick = false;
            _gameTimer.Stop();
        }

        /// <summary>
        /// 继续计时
        /// </summary>
        public static void GoOn()
        {
            _isTick = true;
            _gameTimer.Start();
        }

        /// <summary>
        ///     计时速度，标准速度1s=20min
        /// </summary>
        public static int TimeSpeed { get; private set; } = 1;

        /// <summary>
        /// 加速计时
        /// </summary>
        public static void SpeedSetQuick()
        {
            if (TimeSpeed != 6) TimeSpeed = 6;
        }

        /// <summary>
        /// 正常速度
        /// </summary>
        public static void SpeedSetNormal()
        {
            if(TimeSpeed != 1)TimeSpeed = 1;
        }

        public static bool IsTicking() => _isTick;
        #endregion 纯时间操作

        #region 时间步进详细行为

        /// <summary>
        ///     确定时间表
        /// </summary>
        private static readonly List<Checkpoint.Checkpoint> _timeTable = new List<Checkpoint.Checkpoint>();

        /// <summary>
        ///     往timetable中加入Checkpoint
        /// </summary>
        /// <param name="checkpoint"></param>
        public static void AddCheckpoint(Checkpoint.Checkpoint checkpoint) => _timeTable.Add(checkpoint);

        /// <summary>
        ///     从timetable中删去Checkpoint
        /// </summary>
        /// <param name="checkpoint"></param>
        public static void RemoveCheckpoint(Checkpoint.Checkpoint checkpoint) => _timeTable.Remove(checkpoint);

        #region XML操作

        /// <summary>
        ///     将timetable写入xml
        /// </summary>
        public static void SaveCheckpointListXml(Player.Player player)
        {
            var xd = new XDocument(new XElement("CheckpointList"));
            (from checkpoint in _timeTable
             where checkpoint.CheckpointIsConstant == false
             select checkpoint).ForEach(cp => xd.Element("CheckpointList")?.Add(cp.ConvertCheckpointToXElement()));
            Debug.WriteLine(xd);

            // var path = HttpContext.Current.Server.MapPath("~/Data/CheckpointList/checkpoints.xml");
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/" + player.PlayerNumber + "/checkpoints.xml");
            xd.Save(path);
            if (File.Exists(path)) Debug.WriteLine("Saved!");
            Debug.WriteLine(path);
        }

        /// <summary>
        ///     从XML中读取CheckpointList
        /// </summary>
        public static void ReadCheckpointListXml(Player.Player player)
        {
            // var path = HttpContext.Current.Server.MapPath("~/Data/CheckpointList/checkpoints.xml");
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/"+player.PlayerNumber+"/checkpoints.xml");
            var xd   = XDocument.Load(path);

            foreach (var element in (xd.Element("CheckpointList")?.Elements("Checkpoint") ??
                                     throw new InvalidOperationException())
               .Select(xe => xe))
            {
                var tempCp = Checkpoint.Checkpoint.ReadCheckpointXml(element, player);
                if (!CheckpointListContains(tempCp)) AddCheckpoint(tempCp);
            }
        }

        /// <summary>
        /// 查看时间表中是否已经有了Checkpoint
        /// </summary>
        /// <param name="cp"></param>
        /// <returns></returns>
        private static bool CheckpointListContains(Checkpoint.Checkpoint cp)=> _timeTable.Any(checkpoint => checkpoint == cp);


        #endregion XML操作

        /// <summary>
        ///     刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Update(object sender, ElapsedEventArgs e)
        {
            for (var i = 0; i < _timeTable.Count; i++)
            {
                if (_timeTable[i].CheckFinish())
                {
                    _timeTable[i].InvokeCheckpointEvent();
                    if (!_timeTable[i].CheckpointIsConstant)
                        RemoveCheckpoint(_timeTable[i]);
                    // SimulatorTimer.SaveCheckpointListXml(PageBase.PagePlayer);
                    PageBase.SaveGame();
                    PlayerSqlController
                       .UpdatePlayerInfoSql(PlayerSqlController.ReadPlayerInfoSql(PageBase.PagePlayer.PlayerNumber,false),
                                            PageBase.PagePlayer);
                    continue;
                }

                _timeTable[i].UpdateCheckpoint();
            }
        }

        #endregion 时间步进详细行为
    }
}