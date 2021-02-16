using System.Linq;
using Enemy;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private float fireRadius = 50f;
    [SerializeField] private float fireSpeed = 50f;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject arrowPrefab;
    

    public GameObject LookingForTarget()
    {
        var enemies = EnemySpawner.Instance.Enemies;
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
            arrow.transform.LookAt(enemy.transform);
            var direction = new Vector3(enemyPosition.x - gunPosition.x, 1, enemyPosition.z - gunPosition.z).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * fireSpeed;
        }
    }
}
