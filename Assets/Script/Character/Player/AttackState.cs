using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Character.Player
{
    public class AttackState : PlayerStateBase
    {
        public AttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }
        public override void Enter()
        {
            stateMachine.Animator.Play(stateMachine.AttackHash, 1);
        }

        public override void Tick()
        {
        }

        public override void Exit()
        {
        }
    }
}
