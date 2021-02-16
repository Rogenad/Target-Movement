using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public static Vector3 SetProgress(float currentAmount, float maxAmount)
    {
        var currentProgress = Mathf.Clamp01(currentAmount / maxAmount);
        return new Vector3(currentProgress, 1, 1);
    }
    
}
