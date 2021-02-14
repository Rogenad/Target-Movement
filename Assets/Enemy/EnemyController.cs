using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private readonly Vector3[] _path = new Vector3[3];
        
        [SerializeField] private TerrainRandomPointProvider pointProvider;
        [SerializeField] private float maxHealth;
        [SerializeField] private float stopSpeed = 0.5f;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private HealthBarController healthBarController;
        [SerializeField] private NavMeshAgent enemyAgent;
        
        private GameObject _healthBar;
        private float _currentHealth;
        
        private  void Start()
        {
            _healthBar = healthBarController.CreateHealthBar(gameObject.transform);
            _currentHealth = maxHealth;
            
            for (var i = 0; i < 3; i++)
            {
                _path[i] = pointProvider.GetPoint();
            }
        }
        
        private void Update()
        {
            UpdateTarget();
        }

        private void UpdateTarget()
        {
            if (!enemyAgent.hasPath && Mathf.Abs(enemyAgent.velocity.magnitude) < stopSpeed)
            {
                enemyAgent.destination = _path[Random.Range(0, 3)];
            }
        }

        public void ReceiveDamage(int minDamage, int maxDamage)
        {
            _currentHealth -= Random.Range(minDamage, maxDamage);
            healthBarController.UpdateHealthBar(_healthBar, maxHealth, _currentHealth);
            
            if (_currentHealth <= 0)
            {
                var aliveEnemies = enemySpawner.Enemies;
                aliveEnemies.Remove(gameObject);
                Destroy(_healthBar);
                Destroy(gameObject);
            }
        }


    }
}
