using Enemy;
using UnityEngine;

namespace Arrow
{
    public class ArrowHit : MonoBehaviour
    {
        [SerializeField] 
        private ArrowBounceController _bounceController;
        private EnemyController _enemy;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var player = PlayerController.Instance;
                _enemy = other.gameObject.GetComponent<EnemyController>();
                _enemy.ReceiveDamage(player.MinDamage, player.MaxDamage);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Navigation Static") || other.gameObject.CompareTag("Arrow"))
                _bounceController.AddBounce();
            else Destroy(gameObject);
        }
    }
}
