using System;
using System.Diagnostics;

namespace GameStdioManager.Models.Checkpoint
{


    /// <summary>
    ///     检查点处理委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public class Checkpoint : SimulatorBase
    {
        #region 基本属性

        /// <summary>
        ///     检查点序号
        /// </summary>
        public int CheckpointNumber { get; }

        /// <summary>
        ///     检查点时间
        /// </summary>
        public DateTime CheckpointTime { get; }

        /// <summary>
        ///     检查点执行事件
        /// </summary>
        public string CheckpointProcess;

        /// <summary>
        ///     检查点事件传参
        /// </summary>
        public CheckpointArgs CheckpointTransferArgs;

        /// <summary>
        ///     检查点事件传递对象
        /// </summary>
        public object CheckpointTransferObject;

        #endregion

        #region 构造函数

        public Checkpoint(int checkpointNumber, DateTime checkpointTime)
        {
            CheckpointNumber = checkpointNumber;
            CheckpointTime   = checkpointTime;
        }

        /// <summary>
        /// </summary>
        /// <param name="checkpointNumber"></param>
        /// <param name="checkpointTime"></param>
        /// <param name="checkpointHandler">格式：完整类名.方法</param>
        public Checkpoint(int            checkpointNumber,       DateTime checkpointTime, string checkpointProcess,
                          CheckpointArgs checkpointTransferArgs, object   checkpointTransferObject)
        {
            CheckpointNumber         = checkpointNumber;
            CheckpointTime           = checkpointTime;
            CheckpointProcess        = checkpointProcess;
            CheckpointTransferArgs   = checkpointTransferArgs;
            CheckpointTransferObject = checkpointTransferObject;
        }

        #endregion

        #region 事件处理

        /// <summary>
        ///     从事件名在CheckpointProcessing中触发对应事件
        /// </summary>
        /// <param name="target">目标事件名称</param>
        /// <returns></returns>
        public void InvokeCheckpointEvent()
        {
            Debug.WriteLine("Invoke" + CheckpointProcess);
            typeof(CheckpointsProcessing)
               .GetMethod("Invoke" + CheckpointProcess)
              ?.Invoke(this,
                       new[]
                       {
                           CheckpointTransferObject,
                           CheckpointTransferArgs
                       });
        }

        #endregion
    }
}