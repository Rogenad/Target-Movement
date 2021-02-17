using Enemy;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    UnityEvent _OnPlayerDeath;
    [SerializeField]
    private GameObject _healthBar;
    [SerializeField]
    private int _maxHealth;
    private int _currentHealth;
    
    public static PlayerController Instance { get; private set; }
    public int MaxDamage { get; set; } = 20;
    public int MinDamage { get; set; } = 10;
    public int CurrentHealth
    { 
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            _healthBar.transform.localScale = ProgressBar.SetProgress(_currentHealth, _maxHealth);
        }
    }

    private void Start()
    {
        Instance = this;
        _currentHealth = _maxHealth;
    }

    private void ReceiveDamage(int minReceivingDamage, int maxReceivingDamage)
    {
        CurrentHealth -= Random.Range(minReceivingDamage, maxReceivingDamage);
        if (CurrentHealth < 0)
        {
            gameObject.SetActive(false);
            _OnPlayerDeath.Invoke();
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
