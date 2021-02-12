using Enemy;
using UnityEngine;

namespace Arrow
{
    public class ArrowHit : MonoBehaviour
    {
        [SerializeField] private int minDamage;
        [SerializeField] private int maxDamage;
        [SerializeField] private ArrowBounceController bounceController;
        
        private EnemyController _enemy;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _enemy = other.gameObject.GetComponent<EnemyController>();
                _enemy.ReceiveDamage(minDamage, maxDamage);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Navigation Static"))
                bounceController.AddBounce();
            else Destroy(gameObject);
        }
    }
}
