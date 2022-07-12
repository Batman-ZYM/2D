using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class StateMachineBase : MonoBehaviour
    {
        private IStateBase _currentState;

        // Update is called once per frame
        protected virtual void FixedUpdate()
        {
            _currentState.Tick();
        }
        public void SwitchState(IStateBase state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}