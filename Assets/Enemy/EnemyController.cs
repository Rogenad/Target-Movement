using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public GameObject terrain;
        public float maxHealth;
        public EnemyHealthBarController healthBar;
        [NonSerialized]
        public float currentHealth;
        
        private Terrain _terrain;
        private Vector3 _minVector = new Vector3(0, 0, 0);
        private Vector3 _maxVector;
        private float _stopSpeed = 0.5f;

        private Vector3[] path = new Vector3[3];
        private NavMeshAgent _enemyAgent;
        // Start is called before the first frame update
        private  void Start()
        {
            healthBar.SetMaxHealth(maxHealth);
            currentHealth = maxHealth;
            
            _terrain = terrain.GetComponent<Terrain>();
            _enemyAgent = GetComponent<NavMeshAgent>();
            _maxVector = _terrain.terrainData.size;
            for (int i = 0; i < 3; i++)
            {
                path[i] = new Vector3(Random.Range(_minVector.x, _maxVector.x),
                    0, Random.Range(_minVector.z, _maxVector.z));
            }
            
            transform.position = new Vector3(Random.Range(_minVector.x, _maxVector.x),
                0, Random.Range(_minVector.z, _maxVector.z));
        }

        private void UpdateTarget()
        {
            if (!_enemyAgent.hasPath && Mathf.Abs(_enemyAgent.velocity.magnitude) < _stopSpeed)
            {
                _enemyAgent.destination = path[Random.Range(0, 3)];
            }
        }

        // Update is called once per frame
        private void Update()
        {
            healthBar.UpdateHealthBar(currentHealth);
            UpdateTarget();
        }
    }
}
