using System;

namespace GameStdioManager.Models.Checkpoint
{
    /// <summary>
    ///     检查点传参类
    /// </summary>
    public class CheckpointArgs : EventArgs
    {
        public int CheckParm = 0;

        public float UpdateParm = 0f;

        public float UpdateSpeed = 0f;

        public CheckpointArgs()
        {
        }

        public CheckpointArgs(int checkParm, int updateParm, int updateSpeed)
        {
            CheckParm   = checkParm;
            UpdateParm  = updateParm;
            UpdateSpeed = updateSpeed;
        }
    }

    public delegate void CheckpointHandler(SimulatorBase sender, CheckpointArgs args);

    public delegate bool CheckpointChecker(SimulatorBase sender, CheckpointArgs args);
}