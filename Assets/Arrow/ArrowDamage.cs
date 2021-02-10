using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    public int maxDamage;
    public int minDamage;

    public void DealDamage(ref float currentHealth)
    {
        currentHealth -= Random.Range(maxDamage, minDamage);
    }
}
