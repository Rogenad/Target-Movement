using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    public float shootingAnimationTime;
    public PlayerFire playerFire;
    
    private Animator _animator;
    private NavMeshAgent _agent;
    
    private float stopSpeed = 0.5f;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int IsShooting = Animator.StringToHash("isShooting");
    private static readonly int ShotSpeed = Animator.StringToHash("shotSpeed");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveAnimation();
        ShotAnimation();
    }
    
    private void MoveAnimation()
    {
        _animator.SetBool(IsRunning, Mathf.Abs(_agent.velocity.magnitude) > stopSpeed);
    }

    private void ShotAnimation()
    {
        if (!_animator.GetBool(IsRunning) && playerFire.LookingForTarget() != null)
        {
            _animator.SetTrigger(IsShooting);
            _animator.SetFloat(ShotSpeed, shootingAnimationTime);
        }
    }


}
