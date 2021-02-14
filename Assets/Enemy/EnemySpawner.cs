using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies { get; } = new List<GameObject>();

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private TerrainRandomPointProvider pointProvider;
    [SerializeField] private float spawnDelay = 10;

    private float _lastSpawn;

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > _lastSpawn)
        {
            var spawnedEnemy = Instantiate(enemyPrefab, pointProvider.GetPoint(), Quaternion.identity);
            spawnedEnemy.SetActive(true);
            Enemies.Add(spawnedEnemy);
            _lastSpawn += spawnDelay;
        }
    }

    
}
