using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public static void SetProgress(out Vector3 barToFill, float currentAmount, float maxAmount)
    {
        var currentProgress = Mathf.Clamp01(currentAmount / maxAmount);
        barToFill =  new Vector3(currentProgress, 1, 1);
    }
    
}
