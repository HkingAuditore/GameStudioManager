using System;
using System.Linq;
using WebGrease.Css.Extensions;

namespace GameStdioManager.Models.Checkpoint
{
    /// <summary>
    ///     检查点处理委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public partial class Checkpoint : SimulatorBase
    {
        #region 判定方法

        public bool CheckTimeAndProcess(object sender, CheckpointArgs args) =>
            args.UpdateParm >= 100 || SimulatorTimer.GameTimeNow >= CheckpointTime;

        #endregion 判定方法

        #region 解析逻辑

        /// <summary>
        ///     根据Indicator设置事件与委托
        /// </summary>
        private void GenerateCheckpoint()
        {
            // 设置类型
            switch (CheckpointTypeIndicator)
            {
                case "Game":
                    _soureceType = typeof(Game.Game);
                    break;

                case "Staff":
                    _soureceType = typeof(Staff.Staff);
                    break;

                case "Studio":
                    _soureceType = typeof(Studio.Studio);
                    break;
            }

            if (_soureceType != null)
            {
                // 抓取process方法并订阅Process事件
                (from st in CheckpointProcessIndicators
                 select _soureceType.GetMethod(st)
                 into pc
                 where pc != null
                 select pc).ForEach(process => CheckpointProcess +=
                                                   (CheckpointHandler)
                                                   Delegate.CreateDelegate(typeof(CheckpointHandler),
                                                                           process));
                // 抓取update方法并订阅Update事件
                (from st in CheckpointUpdateIndicators
                 select _soureceType.GetMethod(st)
                 into pc
                 where pc != null
                 select pc).ForEach(process => CheckUpdateProcess +=
                                                   (CheckpointHandler)
                                                   Delegate.CreateDelegate(typeof(CheckpointHandler),
                                                                           process));
            }

            _checkFinishMethod = (CheckpointChecker) Delegate.CreateDelegate(typeof(CheckpointChecker), this,
                                                                             GetType()
                                                                                .GetMethod(CheckpointCheckMethodIndicator) ??
                                                                             throw new InvalidOperationException());
        }

        #endregion 解析逻辑

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
        public SimulatorBase CheckpointTransferObject;

        /// <summary>
        ///     检查点操作指示器
        /// </summary>
        public string[] CheckpointProcessIndicators;

        /// <summary>
        ///     检查点更新指示器
        /// </summary>
        public string[] CheckpointUpdateIndicators;

        /// <summary>
        ///     检查点更新指示器
        /// </summary>
        public string CheckpointCheckMethodIndicator;

        /// <summary>
        ///     检查点实例类型指示器
        /// </summary>
        public string CheckpointTypeIndicator;

        #endregion 公共属性

        #region 私有字段

        /// <summary>
        ///     事件完成检查方法,只能有一个
        /// </summary>
        private CheckpointChecker _checkFinishMethod;

        /// <summary>
        ///     检查点执行事件
        /// </summary>
        private event CheckpointHandler CheckpointProcess;

        /// <summary>
        ///     每一次检查时进行的操作
        /// </summary>
        private event CheckpointHandler CheckUpdateProcess;

        private Type _soureceType;

        #endregion 私有字段

        #endregion 基本属性

        #region 构造函数

        public Checkpoint(int      checkpointNumber, DateTime checkpointTime,
                          string[] checkpointProcessIndicator,
                          string[] checkpointUpdateIndicator, string checkpointCheckMethodIndicator,
                          string   checkpointTypeIndicator)
        {
            CheckpointNumber            = checkpointNumber;
            CheckpointTime              = checkpointTime;
            CheckpointProcessIndicators = checkpointProcessIndicator;

            CheckpointUpdateIndicators     = checkpointUpdateIndicator;
            CheckpointCheckMethodIndicator = checkpointCheckMethodIndicator;
            CheckpointTypeIndicator        = checkpointTypeIndicator;

            _checkFinishMethod = (sender, args) => false;
            GenerateCheckpoint();
        }

        public Checkpoint(int           checkpointNumber, DateTime checkpointTime,
                          string[]      checkpointProcessIndicator,
                          string[]      checkpointUpdateIndicator, string         checkpointCheckMethodIndicator,
                          SimulatorBase checkpointTransferObject,  CheckpointArgs checkpointTransferArgs,
                          string        checkpointTypeIndicator)
        {
            CheckpointNumber = checkpointNumber;
            CheckpointTime   = checkpointTime;

            CheckpointProcessIndicators = checkpointProcessIndicator;

            CheckpointUpdateIndicators     = checkpointUpdateIndicator;
            CheckpointCheckMethodIndicator = checkpointCheckMethodIndicator;
            CheckpointTransferObject       = checkpointTransferObject;

            CheckpointTransferArgs  = checkpointTransferArgs;
            CheckpointTypeIndicator = checkpointTypeIndicator;

            _checkFinishMethod = (sender, args) => false;
            GenerateCheckpoint();
        }

        #endregion 构造函数

        #region 事件处理

        /// <summary>
        ///     检查事件完成性
        /// </summary>
        /// <returns></returns>
        public bool CheckFinish() => _checkFinishMethod(CheckpointTransferObject, CheckpointTransferArgs);

        /// <summary>
        ///     激发事件处理
        /// </summary>
        public void InvokeCheckpointEvent() =>
            CheckpointProcess?.Invoke(CheckpointTransferObject, CheckpointTransferArgs);

        /// <summary>
        ///     添加完成操作
        /// </summary>
        /// <param name="process"></param>
        public void AddCheckProcess(CheckpointHandler process) => CheckpointProcess += process;

        /// <summary>
        ///     设置检查方法
        /// </summary>
        /// <param name="checker"></param>
        public void SetCheckMethod(CheckpointChecker checker) => _checkFinishMethod = checker;

        /// <summary>
        ///     添加刷新操作
        /// </summary>
        /// <param name="process"></param>
        public void AddUpdateProcess(CheckpointHandler process) => CheckUpdateProcess += process;

        /// <summary>
        ///     刷新检查点
        /// </summary>
        public void UpdateCheckpoint() => CheckUpdateProcess?.Invoke(CheckpointTransferObject, CheckpointTransferArgs);

        #endregion 事件处理
    }
}