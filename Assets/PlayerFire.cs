using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public float fireRadius = 10f;
    public float fireSpeed = 50f;
    public AnimationController animationController;
    
    public GameObject gun;
    public List<GameObject> enemies;
    public GameObject arrowGameObject;

    public GameObject LookingForTarget()
    {
        return enemies.FirstOrDefault(enemy => Vector3.Distance(enemy.transform.position, transform.position) <= fireRadius);
    }

    public void Shoot()
    {
        var enemy = LookingForTarget();
        if (enemy != null)
        {
            transform.LookAt(enemy.transform);
            var enemyPosition = enemy.transform.position;
            var gunPosition = gun.transform.position;

            var arrow = Instantiate(arrowGameObject, gunPosition, Quaternion.identity);
            arrow.transform.LookAt(enemyPosition);
            enemyPosition.y = 1;
            gunPosition.y = 1;
            var direction = new Vector3(enemyPosition.x - gunPosition.x, 1, enemyPosition.z - gunPosition.z).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * fireSpeed;
        }
    }
}
