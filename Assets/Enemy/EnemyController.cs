using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Terrain terrain;
        [SerializeField] private float maxHealth;
        [SerializeField] private float stopSpeed = 0.5f;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private HealthBarController healthBarController;
        [SerializeField] private NavMeshAgent enemyAgent;

        private GameObject _healthBar;
        private float _currentHealth;
        private readonly Vector3[] _path = new Vector3[3];
        
        private  void Start()
        {
            _healthBar = healthBarController.CreateHealthBar(gameObject.transform);
            _currentHealth = maxHealth;
            
            var terrainSize = terrain.terrainData.size;
            var minVector = Vector3.zero;
            float randomXPoint = 0;
            float randomZPoint = 0;
            
            for (int i = 0; i < 3; i++)
            {
                randomXPoint = Random.Range(minVector.x, terrainSize.x);
                randomZPoint = Random.Range(minVector.z, terrainSize.z);
                _path[i] = new Vector3(randomXPoint, 0, randomZPoint);
            }
            
            transform.position = new Vector3(randomXPoint, 0, randomZPoint);
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
