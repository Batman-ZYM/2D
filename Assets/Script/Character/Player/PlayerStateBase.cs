
namespace Assets.Script.Character.Player
{
    public abstract class PlayerStateBase : IStateBase
    {
        protected PlayerStateMachine stateMachine;
        public PlayerStateBase(PlayerStateMachine stateMachine) => this.stateMachine = stateMachine;
    }
}
