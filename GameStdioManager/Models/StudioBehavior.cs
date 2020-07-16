using System;
using GameStdioManager.Models.Checkpoint;

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
        }

        /// <summary>
        /// 时间管理类
        /// </summary>
        // public SimulatorTimer GameTimer;

        /// <summary>
        ///     游戏初始化
        /// </summary>
        public static event EventHandler<StudioBehaviorArgs> GameInit;

        /// <summary>
        /// 游戏开始
        /// </summary>
        public static event EventHandler<StudioBehaviorArgs> GameStart;

        /// <summary>
        ///     游戏加载
        /// </summary>
        public static event EventHandler<StudioBehaviorArgs> GameReload;

        /// <summary>
        ///     游戏初始化
        /// </summary>
        public void Init()
        {
            GameInit?.Invoke(this, null);
        }

        /// <summary>
        ///     游戏重载
        /// </summary>
        public void Reload()
        {
            GameReload?.Invoke(this, null);
        }

        /// <summary>
        ///     游戏开始
        /// </summary>
        public void Start()
        {
            GameStart?.Invoke(this,null);
        }
    }
}