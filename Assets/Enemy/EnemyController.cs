using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public UnityEvent enemyKilled;
        private readonly Vector3[] _path = new Vector3[3];
        
        [SerializeField] private TerrainRandomPointProvider pointProvider;
        [SerializeField] private float maxHealth;
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
            if (Vector3.Distance(transform.position, enemyAgent.destination) < enemyAgent.stoppingDistance)
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
                enemyKilled.Invoke();
                var aliveEnemies = enemySpawner.Enemies;
                aliveEnemies.Remove(gameObject);
                Destroy(_healthBar);
                Destroy(gameObject);
            }
        }
    }
}
