using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsShooting = Animator.StringToHash("isShooting");
    
        [SerializeField]
        private PlayerFire _playerFire;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Rigidbody _rigidbody;
    
        private void Update()
        {
            MoveAnimation();
            ShotAnimation();
        }
    
        private void MoveAnimation()
        {
            _animator.SetBool(IsRunning, _rigidbody.velocity.magnitude > 0);
        }

        private void ShotAnimation()
        {
            if (!_animator.GetBool(IsRunning) && _playerFire.LookingForTarget() != null)
            {
                _animator.SetTrigger(IsShooting);
            }
        }


    }
}
