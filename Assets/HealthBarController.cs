using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private RectTransform healthBarPanel;

    public GameObject CreateHealthBar(Transform healthBarOwner)
    {
        var createdHealthBar = Instantiate(healthBarPrefab, healthBarPanel);
        createdHealthBar.GetComponent<HealthBar>().SetHealthBarData(healthBarOwner, healthBarPanel);
        return createdHealthBar;
    }

    public void UpdateHealthBar(GameObject healthBar, float maxHealth, float currentHealth)
    {
        var currentHealthInPercent = currentHealth / maxHealth;
        var fillImage = healthBar.GetComponentsInChildren<Image>()[1];
        fillImage.transform.localScale = new Vector3(currentHealthInPercent, 1, 1);
    }

}
