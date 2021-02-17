using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] 
    private GameObject _healthBarPrefab;
    [SerializeField] 
    private RectTransform _healthBarPanel;

    public GameObject CreateHealthBar(Transform healthBarOwner)
    {
        var createdHealthBar = Instantiate(_healthBarPrefab, _healthBarPanel);
        createdHealthBar.GetComponent<HealthBar>().SetHealthBarData(healthBarOwner, _healthBarPanel);
        return createdHealthBar;
    }

    public static void UpdateHealthBar(GameObject healthBar, int currentHealth, int maxHealth)
    {
        var fillImage = healthBar.GetComponentsInChildren<Image>()[1];
        fillImage.transform.localScale = ProgressBar.SetProgress(currentHealth, maxHealth);
    }

}
