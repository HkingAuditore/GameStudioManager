using System;
using GameStdioManager.Models;
using GameStdioManager.Models.Checkpoint;

namespace GameStdioManager.Models.Checkpoint
{
    /// <summary>
    ///     检查点传参类
    /// </summary>
    public class CheckpointArgs : EventArgs
    {
        public int Parm;

        public CheckpointArgs(int parm)
        {
            Parm = parm;
        }
    }
    public delegate void CheckpointHandler(Object sender, CheckpointArgs args);

    public class CheckpointsProcessing
    {
        public static event CheckpointHandler OnGameStartDevelop;
        public static void InvokeOnGameStartDevelop(object sender, CheckpointArgs args) => OnGameStartDevelop?.Invoke(sender, args);

        public static event CheckpointHandler OnGameFinishDevelop;
        public static void InvokeOnGameFinishDevelop(object sender, CheckpointArgs args) => OnGameFinishDevelop?.Invoke(sender, args);

    }

}
