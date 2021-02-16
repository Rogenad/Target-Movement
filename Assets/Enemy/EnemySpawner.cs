using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance { get; private set; }
        public List<GameObject> Enemies { get; } = new List<GameObject>();

        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnDelay = 10;

        private float _lastSpawn;

        private void Awake()
        {
            Instance = this;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time > _lastSpawn)
            {
                var spawnPoint = TerrainRandomPointProvider.Instance.GetPoint();
                var spawnedEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
                spawnedEnemy.SetActive(true);
                Enemies.Add(spawnedEnemy);
                _lastSpawn += spawnDelay;
            }
        }

    
    }
}
