using System.Linq;
using Enemy;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private float _fireRadius = 50f;
    [SerializeField]
    private float _fireSpeed = 50f;
    [SerializeField]
    private GameObject _gun;
    [SerializeField]
    private GameObject _arrowPrefab;
    

    public GameObject LookingForTarget()
    {
        var enemies = EnemySpawner.Instance.Enemies;
        return enemies.FirstOrDefault(enemy => 
            Vector3.Distance(enemy.transform.position, transform.position) <= _fireRadius);
    }

    public void Shoot()
    {
        var enemy = LookingForTarget();
        if (enemy != null)
        {
            transform.LookAt(enemy.transform);
            var enemyPosition = enemy.transform.position;
            var gunPosition = _gun.transform.position;
            var arrow = Instantiate(_arrowPrefab, gunPosition, Quaternion.identity);
            arrow.transform.LookAt(enemy.transform);
            var direction = new Vector3(enemyPosition.x - gunPosition.x, 1, enemyPosition.z - gunPosition.z).normalized;
            arrow.GetComponent<Rigidbody>().velocity = direction * _fireSpeed;
        }
    }
}
