using System;

namespace GameStdioManager.Models
{
    public class StudioBehaviorArgs : EventArgs
    {
    }

    public class StudioBehavior
    {
        SimulatorTimer _timer;

        public StudioBehavior(bool isReload)
        {
            _timer = new SimulatorTimer(isReload);

            GameStart += SimulatorTimer.TimerUpdate;
        }

        /// <summary>
        /// 时间管理类
        /// </summary>
        // public SimulatorTimer GameTimer;

        /// <summary>
        ///     游戏开始
        /// </summary>
        public static event EventHandler<StudioBehaviorArgs> GameStart;

        /// <summary>
        ///     游戏加载
        /// </summary>
        public static event EventHandler<StudioBehaviorArgs> GameReload;

        /// <summary>
        ///     游戏开始
        /// </summary>
        public void Start()
        {
            GameStart?.Invoke(this, null);
        }

        /// <summary>
        ///     游戏重载
        /// </summary>
        public void Reload()
        {
            GameReload?.Invoke(this, null);
        }
    }
}