using System;
using UnityEngine;

public class AttackSpeedBonusCollect : MonoBehaviour
{
    public AnimationController attackSpeedController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attackSpeedController.shootingAnimationTime *= 1.20f;
            Destroy(gameObject);
        }
    }
}
