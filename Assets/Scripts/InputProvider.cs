using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class InputProvider : MonoBehaviour
    {
        public Vector2 MovementVector
        {
            get => _movementVector;
            set => _movementVector = value;
        }

        public Vector2 LookVector
        {
            get => _lookVector;
            set => _lookVector = value;
        }

        [SerializeField]
        private Vector2 _movementVector;

        [SerializeField]
        private Vector2 _lookVector;

        public bool Firing => _firing;


        [SerializeField]
        private bool _firing;

        public void OnMove(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            //context.
            _movementVector = value;
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            //context.
            _lookVector = value;
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _firing = true;
            }
            else if (context.canceled)
            {
                _firing = false;
            }

        }


    }
}
