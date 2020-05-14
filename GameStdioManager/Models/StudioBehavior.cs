using System;

namespace GameStdioManager.Models
{
    public class StudioBehaviorArgs : EventArgs
    {

    }

    public class StudioBehavior
    {
        /// <summary>
        /// 时间管理类
        /// </summary>
        public SimulatorTimer GameTimer;

        /// <summary>
        /// 游戏开始
        /// </summary>
        public event EventHandler<StudioBehaviorArgs> GameStart;

        /// <summary>
        /// 游戏加载
        /// </summary>
        public event EventHandler<StudioBehaviorArgs> GameReload;

        public StudioBehavior()
        {
            GameTimer = new SimulatorTimer(false);

            GameStart += GameTimer.TimerStart;
            
        }

        /// <summary>
        /// 游戏开始
        /// </summary>
        public void Start()
        {
            GameStart?.Invoke(this, null);
        }

        /// <summary>
        /// 游戏重载
        /// </summary>
        public void Reload()
        {
            GameReload?.Invoke(this,null);
        }

    }
}