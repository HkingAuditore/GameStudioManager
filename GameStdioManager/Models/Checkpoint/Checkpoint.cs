using System;

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

        #region 公共属性

        /// <summary>
        ///     检查点序号
        /// </summary>
        public int CheckpointNumber { get; }

        /// <summary>
        ///     检查点时间
        /// </summary>
        public DateTime CheckpointTime { get; }

        /// <summary>
        ///     检查点事件传参
        /// </summary>
        public CheckpointArgs CheckpointTransferArgs;

        /// <summary>
        ///     检查点事件传递对象
        /// </summary>
        public object CheckpointTransferObject;

        /// <summary>
        ///     检查点执行事件
        /// </summary>
        public event CheckpointHandler CheckpointProcess;

        /// <summary>
        /// 每一次检查时进行的操作
        /// </summary>
        public event CheckpointHandler CheckUpdateProcess;


        #endregion


        #region 私有字段

        /// <summary>
        ///     事件完成检查方法,只能有一个
        /// </summary>
        private CheckpointChecker _checkFinishMethod;


        #endregion

        #endregion

        #region 构造函数

        public Checkpoint(int checkpointNumber, DateTime checkpointTime)
        {
            CheckpointNumber   = checkpointNumber;
            CheckpointTime     = checkpointTime;

            _checkFinishMethod = (sender, args) => false;
        }


        public Checkpoint(int    checkpointNumber,         DateTime       checkpointTime, 
                          object checkpointTransferObject, CheckpointArgs checkpointTransferArgs)
        {
            CheckpointNumber         = checkpointNumber;
            CheckpointTime           = checkpointTime;

            CheckpointTransferArgs   = checkpointTransferArgs;
            CheckpointTransferObject = checkpointTransferObject;

            _checkFinishMethod = (sender, args) => false;
        }

        #endregion

        #region 事件处理

        /// <summary>
        ///     检查事件完成性
        /// </summary>
        /// <returns></returns>
        public bool CheckFinish() => _checkFinishMethod(CheckpointTransferObject, CheckpointTransferArgs);

        /// <summary>
        ///     激发事件处理
        /// </summary>
        public void InvokeCheckpointEvent() => CheckpointProcess?.Invoke(CheckpointTransferObject, CheckpointTransferArgs);

        /// <summary>
        /// 添加完成操作
        /// </summary>
        /// <param name="process"></param>
        public void AddCheckProcess(CheckpointHandler process) => CheckpointProcess += process;

        /// <summary>
        /// 设置检查方法
        /// </summary>
        /// <param name="checker"></param>
        public void SetCheckMethod(CheckpointChecker checker) => _checkFinishMethod = checker;

        /// <summary>
        /// 添加刷新操作
        /// </summary>
        /// <param name="process"></param>
        public void AddUpdateProcess(CheckpointHandler process) => CheckUpdateProcess += process;

        /// <summary>
        /// 刷新检查点
        /// </summary>
        public void UpdateCheckpoint() => CheckUpdateProcess?.Invoke(CheckpointTransferObject, CheckpointTransferArgs);


        #endregion
    }
}