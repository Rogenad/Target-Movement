using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private readonly Vector3[] _path = new Vector3[3];
        
        [SerializeField]
        private HealthBarController healthBarController;
        [SerializeField]
        private int _maxHealth;
        [SerializeField]
        private NavMeshAgent _enemyAgent;
        [SerializeField]
        private UnityEvent _OnEnemyKilled;
        private GameObject _healthBar;
        private int _currentHealth;
        
        public int MaxDamage { get; } = 10;
        public int MinDamage { get; } = 5;

        private void Start()
        {
            _healthBar = healthBarController.CreateHealthBar(gameObject.transform);
            _currentHealth = _maxHealth;
            
            for (var i = 0; i < 3; i++)
            {
                _path[i] = TerrainRandomPointProvider.Instance.GetPoint();
            }
        }
        
        private void Update()
        {
            UpdateTarget();
        }
        
        public void ReceiveDamage(int minDamage, int maxDamage)
        {
            _currentHealth -= Random.Range(minDamage, maxDamage);
            HealthBarController.UpdateHealthBar(_healthBar, _currentHealth, _maxHealth);
            if (_currentHealth <= 0)
            {
                _OnEnemyKilled.Invoke();
                var aliveEnemies = EnemySpawner.Instance.Enemies;
                aliveEnemies.Remove(gameObject);
                Destroy(_healthBar);
                Destroy(gameObject);
            }
        }

        private void UpdateTarget()
        {
            var distanceToTarget = Vector3.Distance(transform.position, _enemyAgent.destination);
            if (distanceToTarget < _enemyAgent.stoppingDistance)
            {
                _enemyAgent.destination = _path[Random.Range(0, 3)];
            }
        }
        
    }
}
