using Enemy;
using UnityEngine;

namespace Arrow
{
    public class ArrowHit : MonoBehaviour
    {
        public ArrowDamage damage;
        public ArrowBounceController bounceController;
        
        private EnemyController _enemy;
        private float _currentEnemyHealth;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _enemy = other.gameObject.GetComponent<EnemyController>();
                damage.DealDamage(ref _enemy.currentHealth);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Navigation Static"))
                bounceController.AddBounce();
            else Destroy(gameObject);
        }
    }
}
