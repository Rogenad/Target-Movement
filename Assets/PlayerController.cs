using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private int maxReceivingDamage;
    [SerializeField] private int minReceivingDamage;
    [SerializeField] private HealthBarController healthBarController;

    private GameObject _healthBar;
    private float _currentHealth;
    
    private void Start()
    {
        _healthBar = healthBarController.CreateHealthBar(gameObject.transform);
        _currentHealth = maxHealth;
    }

    private void ReceiveDamage()
    {
        _currentHealth -= Random.Range(minReceivingDamage, maxReceivingDamage);
        healthBarController.UpdateHealthBar(_healthBar, maxHealth, _currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ReceiveDamage();
        }
    }
}
