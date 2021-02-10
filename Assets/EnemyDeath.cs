using Enemy;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public EnemyController enemy;
    public PlayerFire playerFire;
    
    // Update is called once per frame
    void Update()
    {
        if (enemy.currentHealth < 0)
        {
            playerFire.enemies.Remove(gameObject);
            Destroy(gameObject, 1);
        }
    }
}
