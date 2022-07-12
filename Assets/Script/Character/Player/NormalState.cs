using System.Collections;
using UnityEngine;

namespace Assets.Script.Character.Player
{
    /// <summary>
    /// 正常状态
    /// </summary>
    public class NormalState : PlayerStateBase
    {
        public NormalState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Enter()
        {
            stateMachine.Animator.Play(stateMachine.IdleHash, 0);
            stateMachine.InputManager.PlayerJump += PlayerJumpEvent;
            stateMachine.InputManager.PlayerAttack += PlayerAttackEvent;
        }


        public override void Tick()
        {
            MovementEvent();
            CheckGround();
        }


        public override void Exit()
        {
            stateMachine.InputManager.PlayerJump -= PlayerJumpEvent;
            stateMachine.InputManager.PlayerAttack -= PlayerAttackEvent;
        }
        private void MovementEvent()
        {
            stateMachine.Rigidbody.velocity = stateMachine.InputManager.MovementValue * 
                stateMachine.BaseState.MovementSpeed;

            stateMachine.Animator.Play(stateMachine.RunHash, 0);

            if(stateMachine.InputManager.MovementValue.x != 0)
            {
                stateMachine.transform.localScale = new Vector3(stateMachine.InputManager.MovementValue.x, 1, 1);
            }
        }
        private void PlayerJumpEvent()
        {
            stateMachine.Rigidbody.AddForce(new Vector2(0, stateMachine.BaseState.JumpForce), ForceMode2D.Impulse);
        }
        private void CheckGround()
        {
            stateMachine.IsGround = Physics2D.OverlapCircle(stateMachine.CheckGround.CurrentPostion.position, 
                stateMachine.CheckGround.CurrentRadius, stateMachine.CheckGround.CurrentLayerMask);

            stateMachine.IsJump = !stateMachine.IsGround;
        }
        private void PlayerAttackEvent()
        {
            stateMachine.SwitchState(new AttackState(stateMachine));
        }
    }
}