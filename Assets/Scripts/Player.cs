using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    internal class Player : MonoBehaviour, IPauseable
    {
        [SerializeField]
        private InputAction _leftStrafeAction = null;
        [SerializeField]
        private InputAction _rightStrafeAction = null;
        [SerializeField]
        private Rigidbody _body = null;

        [SerializeField]
        private Vector3 _movementVector = Vector3.zero;
        [SerializeField]
        private float _pollingInterval = 0f;

        public float MaximumX = 0f;

        private void Start()
        {
            InitializeInputActions();
            ListenForInput();
        }

        private void InitializeInputActions()
        {
            _leftStrafeAction.Enable();
            _rightStrafeAction.Enable();
        }

        private async void ListenForInput()
        {
            while (true)
            {
                Vector3 position = Vector3.zero;
                if (_leftStrafeAction.IsPressed())
                {
                    position = transform.position;
                    position -= _movementVector;
                    position.x = Mathf.Clamp(position.x, MaximumX * -1, MaximumX);
                    transform.position = position;
                }
                if (_rightStrafeAction.IsPressed())
                {
                    position = transform.position;
                    position += _movementVector;
                    position.x = Mathf.Clamp(position.x, MaximumX * -1, MaximumX);
                    transform.position = position;
                }
                await Task.Delay(TimeSpan.FromSeconds(_pollingInterval));
            }
        }

        public void TogglePause()
        {
            ToggleInputAction(_leftStrafeAction);
            ToggleInputAction(_rightStrafeAction);
        }

        private void ToggleInputAction(InputAction action)
        {
            if (action.enabled)
            {
                action.Disable();
            }
            else
            {
                action.Enable();
            }
        }
    }
}
