using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int IsShooting = Animator.StringToHash("isShooting");

    [SerializeField] private PlayerFire playerFire;
    [SerializeField] private float stopSpeed = 0.5f;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    // Update is called once per frame
    private void Update()
    {
        MoveAnimation();
        ShotAnimation();
    }
    
    private void MoveAnimation()
    {
        animator.SetBool(IsRunning, Mathf.Abs(agent.velocity.magnitude) > stopSpeed);
    }

    private void ShotAnimation()
    {
        if (!animator.GetBool(IsRunning) && playerFire.LookingForTarget() != null)
        {
            animator.SetTrigger(IsShooting);
        }
    }


}
