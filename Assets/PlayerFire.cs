using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public float fireRadius = 1000f;
    public float fireCoolDown = 1f;
    public GameObject bullet;
    
    private float _lastFire;
    private float fireSpeed = 10f;
    private GameObject[] _enemies;
    private GameObject _gun;

    // Start is called before the first frame update
    void Start()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _gun = GameObject.FindGameObjectsWithTag("Gun")[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_enemies[_enemies.Length - 1] == null)
        {
            Time.timeScale = 0;
        }
        Shoot();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Shoot()
    {
        foreach (var enemy in _enemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) <= fireRadius && Time.time > _lastFire)
            {
                gameObject.transform.LookAt(enemy.transform);
                
                var position = _gun.transform.position;
                GameObject b = Instantiate(bullet, position, Quaternion.identity);
                
                var direction = (enemy.transform.position - position).normalized;
                Debug.Log(b.GetComponent<Rigidbody>().velocity = direction * fireSpeed);
                b.GetComponent<Rigidbody>().velocity = direction * fireSpeed;
                
                _lastFire = Time.time + fireCoolDown;
            }
        }
    }
}
