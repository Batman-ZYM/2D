using System.Collections;
using UnityEngine;
using Assets.Script;
using Assets.Script.Manager;

namespace Assets.Script.Character.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    /// <summary>
    /// 玩家控制器,玩家状态机
    /// </summary>
    public class PlayerStateMachine : StateMachineBase
    {
        private static readonly PlayerBaseState playerBaseState = new();
        public PlayerBaseState BaseState = playerBaseState;

        private static readonly CheckGround checkGround = new();
        public CheckGround CheckGround = checkGround;

        //Animator Hash
        public readonly int IdleHash = Animator.StringToHash("Idle");
        public readonly int RunHash = Animator.StringToHash("Run");
        public readonly int JumpHash = Animator.StringToHash("Jump");
        public readonly int FallHash = Animator.StringToHash("Fall");
        public readonly int AttackHash = Animator.StringToHash("Attack");

        //当前状态
        public bool IsJump;
        public bool IsGround;

        //必备组件
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public InputManager InputManager { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        private void Start()
        {
            //初始化状态
            SwitchState(new NormalState(this));
        }
    }
    /// <summary>
    /// 角色基础属性
    /// </summary>
    [System.Serializable]
    public class PlayerBaseState
    {
        /// <summary>
        /// 移动速度
        /// </summary>
        [field:SerializeField] public float MovementSpeed { get; private set; }
        /// <summary>
        /// 跳跃的力
        /// </summary>
        [field:SerializeField] public float JumpForce { get; private set; }
    }
    /// <summary>
    /// 地面检测
    /// </summary>
    [System.Serializable]
    public class CheckGround
    {
        /// <summary>
        /// 检测物体的位置
        /// </summary>
        [field: SerializeField] public Transform CurrentPostion { get; private set; }
        /// <summary>
        /// 检测的范围
        /// </summary>
        [field: SerializeField] public float CurrentRadius { get; private set; }
        /// <summary>
        /// 被检测的图层
        /// </summary>
        [field: SerializeField] public LayerMask CurrentLayerMask { get; private set; }
    }
}