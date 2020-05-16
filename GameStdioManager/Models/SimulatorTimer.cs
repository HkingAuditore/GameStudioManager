using System;
using System.Collections.Generic;
using System.Timers;
using GameStdioManager.Models.Checkpoint;

namespace GameStdioManager.Models
{
    public class SimulatorTimer
    {
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
        ///     计时速度，标准速度1s=1min
        /// </summary>
        private static readonly int _timeSpeed = 20;

        #endregion

        /// <summary>
        /// 
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

        /// <summary>
        /// 重载时间
        /// </summary>
        private void ReloadTimer()
        {
            
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
            _gameTimer.Elapsed += (s, ea) => { GameTimeNow = GameTimeNow.AddMinutes(_timeSpeed); };
            _gameTimer.Elapsed += CheckCheckpoints;


            _gameTimer.Enabled = true;
            _gameTimer.Start();
        }

        /// <summary>
        /// 获取当前时间n个小时后的时间
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

        #region 时间步进详细行为

        /// <summary>
        /// 时间表
        /// </summary>
        public static List<Checkpoint.Checkpoint> TimeTable = new List<Checkpoint.Checkpoint>();

        private static void CheckCheckpoints(object sender,ElapsedEventArgs e)
        {
            if (TimeTable.Count != 0)
            {
                for (var i = 0; i < TimeTable.Count; i++)
                {
                    var checkpoint = TimeTable[i];
                    if (GameTimeNow >= checkpoint.CheckpointTime)
                    {
                        checkpoint.InvokeCheckpointEvent();
                        TimeTable.Remove(checkpoint);
                    }
                }
            }
        }

        #endregion
    }


}