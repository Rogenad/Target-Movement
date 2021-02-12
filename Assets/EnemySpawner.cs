using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies { get; } = new List<GameObject>();

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay = 5;

    private float _lastSpawn;

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > _lastSpawn)
        {
            var spawnedEnemy = Instantiate(enemyPrefab);
            spawnedEnemy.SetActive(true);
            Enemies.Add(spawnedEnemy);
            _lastSpawn += spawnDelay;
        }
    }

    
}
