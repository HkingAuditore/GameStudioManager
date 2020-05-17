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
        public int CheckParm;

        public int UpdateParm;

        public CheckpointArgs()
        {

        }
    }

    public delegate void CheckpointHandler(Object sender, CheckpointArgs args);

    public delegate bool CheckpointChecker(Object sender, CheckpointArgs args);
}
