using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarController : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void UpdateHealthBar(float currentHealth)
    {
        slider.value = currentHealth;
    }
}
