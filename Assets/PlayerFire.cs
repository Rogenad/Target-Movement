﻿using System.Linq;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private float fireRadius = 50f;
    [SerializeField] private float fireSpeed = 50f;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject arrowPrefab;
    

    public GameObject LookingForTarget()
    {
        var enemies = enemySpawner.Enemies;
        return enemies.FirstOrDefault(enemy => 
            Vector3.Distance(enemy.transform.position, transform.position) <= fireRadius);
    }

    public void Shoot()
    {
        var enemy = LookingForTarget();
        if (enemy != null)
        {
            transform.LookAt(enemy.transform);
            var enemyPosition = enemy.transform.position;
            var gunPosition = gun.transform.position;

            var arrow = Instantiate(arrowPrefab, gunPosition, Quaternion.identity);
            arrow.transform.LookAt(enemyPosition);
            enemyPosition.y = 1;
            gunPosition.y = 1;
            var direction = new Vector3(enemyPosition.x - gunPosition.x, 1, enemyPosition.z - gunPosition.z).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * fireSpeed;
        }
    }
}
