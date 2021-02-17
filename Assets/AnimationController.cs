using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int IsShooting = Animator.StringToHash("isShooting");
    
    [SerializeField]
    private PlayerFire _playerFire;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private NavMeshAgent _agent;
    
    private void Update()
    {
        MoveAnimation();
        ShotAnimation();
    }
    
    private void MoveAnimation()
    {
        var distanceToTarget = Vector3.Distance(_agent.transform.position, _agent.destination);
        _animator.SetBool(IsRunning, distanceToTarget > _agent.stoppingDistance);
    }

    private void ShotAnimation()
    {
        if (!_animator.GetBool(IsRunning) && _playerFire.LookingForTarget() != null)
        {
            _animator.SetTrigger(IsShooting);
        }
    }


}
