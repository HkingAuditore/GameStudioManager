using System;
using System.Timers;

namespace GameStdioManager.Models
{
    public class SimulatorTimer
    {
        /// <summary>
        ///     游戏起始时间
        /// </summary>
        public readonly DateTime GameStartTime;

        /// <summary>
        ///     游戏世界当前时间
        /// </summary>
        public DateTime GameTimeNow;

        /// <summary>
        ///     计时器
        /// </summary>
        private readonly Timer _gameTimer;

        /// <summary>
        ///     计时速度，标准速度1s=1min
        /// </summary>
        private readonly int _timeSpeed = 20;

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
            throw new NotImplementedException();
        }

        /// <summary>
        ///     开始计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TimerStart(object sender, EventArgs e)
        {
            _gameTimer.AutoReset = true;
            // 每次时间步进的操作
            _gameTimer.Elapsed += (s, ea) => { GameTimeNow = GameTimeNow.AddMinutes(_timeSpeed); };
            _gameTimer.Enabled = true;

            _gameTimer.Start();
        }
    }
}