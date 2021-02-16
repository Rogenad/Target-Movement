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

    public static void UpdateHealthBar(GameObject healthBar, int currentHealth, int maxHealth)
    {
        var fillImage = healthBar.GetComponentsInChildren<Image>()[1];
        fillImage.transform.localScale = ProgressBar.SetProgress(currentHealth, maxHealth);
    }

}
