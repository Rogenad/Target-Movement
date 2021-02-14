using UnityEngine;

namespace Bonuses
{
    public class AttackSpeedBonusCollect : MonoBehaviour
    {
        private static readonly int ShotSpeed = Animator.StringToHash("shotSpeed");
        [SerializeField] private Animator attackSpeedController;

        private float _shootingAnimationTime;

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
