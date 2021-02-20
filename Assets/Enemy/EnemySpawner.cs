using System.Collections.Generic;
using Terrain;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;
        [SerializeField]
        private float _spawnDelay = 10;
        private float _lastSpawn;
        
        public static EnemySpawner Instance { get; private set; }
        public List<GameObject> Enemies { get; } = new List<GameObject>();

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (Time.time > _lastSpawn)
            {
                var spawnPoint = TerrainRandomPointProvider.Instance.GetPoint();
                var spawnedEnemy = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
                spawnedEnemy.SetActive(true);
                Enemies.Add(spawnedEnemy);
                _lastSpawn += _spawnDelay;
            }
        }

    
    }
}
