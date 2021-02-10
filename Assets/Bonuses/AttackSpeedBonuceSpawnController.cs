using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackSpeedBonuceSpawnController : MonoBehaviour
{
    public GameObject attackSpeedBonus;
    public Terrain terrain;
    
    private float _spawnDelay = 35;
    private float _lastSpawn;

    private Vector3 _maxVector;
    private Vector3 _minVector = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    private void Start()
    {
        _maxVector = terrain.terrainData.size;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > _lastSpawn)
        {
            Instantiate(attackSpeedBonus, new Vector3(Random.Range(_maxVector.x, _minVector.x), 2,
                Random.Range(_maxVector.z, _minVector.z)),Quaternion.identity);
            _lastSpawn += _spawnDelay;
        }
    }
}
