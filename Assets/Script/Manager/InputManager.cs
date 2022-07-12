using System.Collections;
using UnityEngine;
using Assets.Script;
using UnityEngine.InputSystem;
using System;

namespace Assets.Script.Manager
{
    public class InputManager : MonoBehaviour, InputControls.IPlayerActions
    {
        private InputControls _inputActions;

        //移动方向
        public Vector2 MovementValue { get; private set; }

        //攻击事件
        public event Action PlayerAttack;
        //跳跃事件
        public event Action PlayerJump;
        private void Awake()
        {
            _inputActions = new InputControls();
        }
        void Start()
        {
            _inputActions.Player.SetCallbacks(this);
            _inputActions.Player.Enable();
        }
        private void OnDisable()
        {
            _inputActions.Player.Disable();
        }
        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }
            PlayerJump?.Invoke();
        }

        public void OnAttackBase(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }
            PlayerAttack?.Invoke();
        }
    }
}