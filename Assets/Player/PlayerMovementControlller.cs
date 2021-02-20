using UI.Joystick;
using UnityEngine;

namespace Player
{
    public class PlayerMovementControlller : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidBody;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private JoystickBehaviour _joystick;

        private void Update()
        {
            var direction = new Vector3(_joystick.InputDirection.x, 0, _joystick.InputDirection.y);
            _rigidBody.velocity = direction * _speed;
            if (!direction.Equals(Vector3.zero))
            {
                transform.rotation = Quaternion.LookRotation(_rigidBody.velocity);
            }
        }

    }
}
