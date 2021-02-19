using Enemy;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public int MaxDamage { get; set; } = 20;
    public int MinDamage { get; set; } = 10;
    public int CurrentHealth
    { 
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            ProgressBar.SetProgress(out var healthBarFill, _currentHealth, maxHealth);
            healthBar.transform.localScale = healthBarFill;
        }
    }
    
    public UnityEvent playerDied;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private int maxHealth;
    
    private int _currentHealth;

    private void Start()
    {
        Instance = this;
        _currentHealth = maxHealth;
    }

    private void ReceiveDamage(int minReceivingDamage, int maxReceivingDamage)
    {
        CurrentHealth -= Random.Range(minReceivingDamage, maxReceivingDamage);
        if (CurrentHealth < 0)
        {
            gameObject.SetActive(false);
            playerDied.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<EnemyController>();
            ReceiveDamage(enemy.MinDamage, enemy.MaxDamage);
        }
    }
}
