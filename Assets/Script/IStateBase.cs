namespace Assets.Script
{
    /// <summary>
    /// 基础状态类
    /// </summary>
    public abstract class IStateBase
    {
        /// <summary>
        /// 进入状态时
        /// </summary>
        public abstract void Enter();
        /// <summary>
        /// 保持在状态时
        /// </summary>
        public abstract void Tick();
        /// <summary>
        /// 退出状态时
        /// </summary>
        public abstract void Exit();
    }
}
