using UnityEngine;

namespace Bonuses
{
    public class AttackSpeedBonusCollect : MonoBehaviour
    {
        [SerializeField] 
        private Animator attackSpeedController;

        private float _shootingAnimationTime;
        private static readonly int ShotSpeed = Animator.StringToHash("shotSpeed");

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _shootingAnimationTime = attackSpeedController.GetFloat(ShotSpeed);
                _shootingAnimationTime *= 1.20f;
                attackSpeedController.SetFloat(ShotSpeed, _shootingAnimationTime);
                Destroy(gameObject);
            }
        }
    }
}
