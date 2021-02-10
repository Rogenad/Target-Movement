using Enemy;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    
    private PlayerFire _playerFire;
    private float _spawnDelay = 5;
    private float _lastSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerFire = player.GetComponent<PlayerFire>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _lastSpawn)
        {
            var spawnedEnemy = Instantiate(enemy);
            _lastSpawn += _spawnDelay;
            _playerFire.enemies.Add(spawnedEnemy);
        }
    }
}
